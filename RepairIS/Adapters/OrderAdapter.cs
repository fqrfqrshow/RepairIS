using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RepairIS.Models;

namespace RepairIS.Adapters
{
    /// <summary>
    /// Адаптер для работы со станками (Machine) и заявками (Request).
    /// Реализует паттерн Adapter для изоляции логики работы с JSON-файлами.
    /// </summary>
    public class OrderAdapter
    {
        private readonly string _machinesFile;
        private readonly string _ordersFile;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly object _fileLock = new object();

        /// <summary>
        /// Событие, возникающее при изменении данных станков
        /// </summary>
        public event EventHandler<MachineChangedEventArgs> MachineChanged;

        /// <summary>
        /// Событие, возникающее при создании новой заявки
        /// </summary>
        public event EventHandler<RequestCreatedEventArgs> RequestCreated;

        /// <summary>
        /// Конструктор с возможностью указать пути к файлам (для тестирования)
        /// </summary>
        public OrderAdapter(string machinesFilePath = "machines.json", string ordersFilePath = "orders.json")
        {
            _machinesFile = machinesFilePath ?? throw new ArgumentNullException(nameof(machinesFilePath));
            _ordersFile = ordersFilePath ?? throw new ArgumentNullException(nameof(ordersFilePath));
            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        #region Machine Methods

        /// <summary>
        /// Возвращает список всех станков
        /// </summary>
        public List<Machine> GetAllMachines()
        {
            if (!File.Exists(_machinesFile))
                return new List<Machine>();

            lock (_fileLock)
            {
                return LoadMachinesInternal();
            }
        }

        /// <summary>
        /// Возвращает станки пользователя по OwnerId
        /// </summary>
        public List<Machine> GetMachinesByOwnerId(int ownerId)
        {
            if (ownerId <= 0)
                throw new ArgumentException("OwnerId должен быть больше 0", nameof(ownerId));

            var allMachines = GetAllMachines();
            return allMachines.Where(m => m.OwnerId == ownerId).ToList();
        }

        /// <summary>
        /// Возвращает станки пользователя в формате JSON
        /// </summary>
        public string FetchMachines(int userId)
        {
            var machines = GetMachinesByOwnerId(userId);
            return JsonConvert.SerializeObject(machines, _jsonSettings);
        }

        /// <summary>
        /// Возвращает станок по ID
        /// </summary>
        public Machine GetMachineById(int machineId)
        {
            if (machineId <= 0)
                throw new ArgumentException("ID станка должен быть больше 0", nameof(machineId));

            var allMachines = GetAllMachines();
            return allMachines.FirstOrDefault(m => m.Id == machineId);
        }

        /// <summary>
        /// Возвращает станок по ID в формате JSON
        /// </summary>
        public string FetchMachineById(int machineId)
        {
            var machine = GetMachineById(machineId);
            return JsonConvert.SerializeObject(machine, _jsonSettings);
        }

        /// <summary>
        /// Добавляет новый станок
        /// </summary>
        /// <returns>ID добавленного станка</returns>
        public int AddMachine(Machine machine)
        {
            if (machine == null)
                throw new ArgumentNullException(nameof(machine));

            if (string.IsNullOrWhiteSpace(machine.Model))
                throw new ArgumentException("Модель станка не может быть пустой", nameof(machine));

            if (machine.OwnerId <= 0)
                throw new ArgumentException("OwnerId должен быть больше 0", nameof(machine));

            lock (_fileLock)
            {
                var machines = LoadMachinesInternal();

                // Проверка на дубликат по серийному номеру
                if (!string.IsNullOrWhiteSpace(machine.SerialNumber) &&
                    machines.Any(m => m.SerialNumber == machine.SerialNumber))
                {
                    throw new InvalidOperationException($"Станок с серийным номером '{machine.SerialNumber}' уже существует");
                }

                machine.Id = machines.Count > 0 ? machines.Max(m => m.Id) + 1 : 1;
                machines.Add(machine);

                SaveMachinesInternal(machines);
                OnMachineChanged(new MachineChangedEventArgs(machine.Id, MachineAction.Added));

                return machine.Id;
            }
        }

        /// <summary>
        /// Добавляет новый станок из JSON-строки
        /// </summary>
        public void PostMachine(string machineJson)
        {
            if (string.IsNullOrWhiteSpace(machineJson))
                throw new ArgumentException("JSON станка не может быть пустым", nameof(machineJson));

            var machine = JsonConvert.DeserializeObject<Machine>(machineJson);
            AddMachine(machine);
        }

        /// <summary>
        /// Обновляет данные станка
        /// </summary>
        public bool UpdateMachine(Machine updatedMachine)
        {
            if (updatedMachine == null)
                throw new ArgumentNullException(nameof(updatedMachine));

            if (updatedMachine.Id <= 0)
                throw new ArgumentException("ID станка должен быть больше 0", nameof(updatedMachine));

            lock (_fileLock)
            {
                var machines = LoadMachinesInternal();
                var existing = machines.FirstOrDefault(m => m.Id == updatedMachine.Id);

                if (existing == null)
                    return false;

                existing.Model = updatedMachine.Model;
                existing.SerialNumber = updatedMachine.SerialNumber;
                existing.Manufacturer = updatedMachine.Manufacturer;
                existing.OwnerId = updatedMachine.OwnerId;

                SaveMachinesInternal(machines);
                OnMachineChanged(new MachineChangedEventArgs(updatedMachine.Id, MachineAction.Updated));

                return true;
            }
        }

        /// <summary>
        /// Удаляет станок по ID
        /// </summary>
        public bool DeleteMachine(int machineId)
        {
            if (machineId <= 0)
                throw new ArgumentException("ID станка должен быть больше 0", nameof(machineId));

            lock (_fileLock)
            {
                var machines = LoadMachinesInternal();
                var machine = machines.FirstOrDefault(m => m.Id == machineId);

                if (machine == null)
                    return false;

                machines.Remove(machine);
                SaveMachinesInternal(machines);
                OnMachineChanged(new MachineChangedEventArgs(machineId, MachineAction.Deleted));

                return true;
            }
        }

        /// <summary>
        /// Проверяет, существует ли станок с указанным ID
        /// </summary>
        public bool MachineExists(int machineId)
        {
            return GetMachineById(machineId) != null;
        }

        #endregion

        #region Request Methods

        /// <summary>
        /// Возвращает список всех заявок
        /// </summary>
        public List<Request> GetAllRequests()
        {
            if (!File.Exists(_ordersFile))
                return new List<Request>();

            lock (_fileLock)
            {
                return LoadRequestsInternal();
            }
        }

        /// <summary>
        /// Возвращает заявку по ID
        /// </summary>
        public Request GetRequestById(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(requestId));

            var allRequests = GetAllRequests();
            return allRequests.FirstOrDefault(r => r.Id == requestId);
        }

        /// <summary>
        /// Возвращает заявки клиента
        /// </summary>
        public List<Request> GetRequestsByClientId(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("ClientId должен быть больше 0", nameof(clientId));

            var allRequests = GetAllRequests();
            return allRequests.Where(r => r.ClientId == clientId).ToList();
        }

        /// <summary>
        /// Возвращает заявки мастера
        /// </summary>
        public List<Request> GetRequestsByMasterId(int masterId)
        {
            if (masterId <= 0)
                throw new ArgumentException("MasterId должен быть больше 0", nameof(masterId));

            var allRequests = GetAllRequests();
            return allRequests.Where(r => r.MasterId == masterId).ToList();
        }

        /// <summary>
        /// Создает новую заявку на ремонт
        /// </summary>
        /// <returns>ID созданной заявки</returns>
        public int CreateRequest(Request request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.MachineId <= 0)
                throw new ArgumentException("MachineId должен быть больше 0", nameof(request));

            if (request.ClientId <= 0)
                throw new ArgumentException("ClientId должен быть больше 0", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Description))
                throw new ArgumentException("Описание проблемы не может быть пустым", nameof(request));

            if (string.IsNullOrWhiteSpace(request.ContactPhone))
                throw new ArgumentException("Контактный телефон не может быть пустым", nameof(request));

            lock (_fileLock)
            {
                var requests = LoadRequestsInternal();

                request.Id = requests.Count > 0 ? requests.Max(r => r.Id) + 1 : 1;
                request.Status = "Ожидает обработки";
                request.CreatedAt = DateTime.Now;
                request.MasterId = 0;

                requests.Add(request);

                SaveRequestsInternal(requests);
                OnRequestCreated(new RequestCreatedEventArgs(request.Id, request.ClientId));

                return request.Id;
            }
        }

        /// <summary>
        /// Добавляет новую заявку из JSON-строки
        /// </summary>
        public void PostOrder(string orderJson)
        {
            if (string.IsNullOrWhiteSpace(orderJson))
                throw new ArgumentException("JSON заявки не может быть пустым", nameof(orderJson));

            var request = JsonConvert.DeserializeObject<Request>(orderJson);
            CreateRequest(request);
        }

        /// <summary>
        /// Обновляет статус заявки
        /// </summary>
        public bool UpdateRequestStatus(int requestId, string newStatus)
        {
            if (requestId <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(requestId));

            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Статус не может быть пустым", nameof(newStatus));

            lock (_fileLock)
            {
                var requests = LoadRequestsInternal();
                var request = requests.FirstOrDefault(r => r.Id == requestId);

                if (request == null)
                    return false;

                request.Status = newStatus;
                SaveRequestsInternal(requests);

                return true;
            }
        }

        /// <summary>
        /// Обновляет заявку
        /// </summary>
        public bool UpdateRequest(Request updatedRequest)
        {
            if (updatedRequest == null)
                throw new ArgumentNullException(nameof(updatedRequest));

            if (updatedRequest.Id <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(updatedRequest));

            lock (_fileLock)
            {
                var requests = LoadRequestsInternal();
                var existing = requests.FirstOrDefault(r => r.Id == updatedRequest.Id);

                if (existing == null)
                    return false;

                existing.MachineId = updatedRequest.MachineId;
                existing.MasterId = updatedRequest.MasterId;
                existing.ClientId = updatedRequest.ClientId;
                existing.Status = updatedRequest.Status;
                existing.Description = updatedRequest.Description;
                existing.ContactPhone = updatedRequest.ContactPhone;
                existing.InspectionMethod = updatedRequest.InspectionMethod;

                SaveRequestsInternal(requests);
                return true;
            }
        }

        /// <summary>
        /// Удаляет заявку по ID
        /// </summary>
        public bool DeleteRequest(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(requestId));

            lock (_fileLock)
            {
                var requests = LoadRequestsInternal();
                var request = requests.FirstOrDefault(r => r.Id == requestId);

                if (request == null)
                    return false;

                requests.Remove(request);
                SaveRequestsInternal(requests);

                return true;
            }
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Удаляет все станки (для тестирования)
        /// </summary>
        public void ClearAllMachines()
        {
            lock (_fileLock)
            {
                if (File.Exists(_machinesFile))
                {
                    File.Delete(_machinesFile);
                }
            }
        }

        /// <summary>
        /// Удаляет все заявки (для тестирования)
        /// </summary>
        public void ClearAllRequests()
        {
            lock (_fileLock)
            {
                if (File.Exists(_ordersFile))
                {
                    File.Delete(_ordersFile);
                }
            }
        }

        #endregion

        #region Private Methods

        private List<Machine> LoadMachinesInternal()
        {
            if (!File.Exists(_machinesFile))
                return new List<Machine>();

            try
            {
                string json = File.ReadAllText(_machinesFile);
                return JsonConvert.DeserializeObject<List<Machine>>(json) ?? new List<Machine>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации файла {_machinesFile}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при чтении файла {_machinesFile}", ex);
            }
        }

        private void SaveMachinesInternal(List<Machine> machines)
        {
            try
            {
                string json = JsonConvert.SerializeObject(machines, _jsonSettings);
                File.WriteAllText(_machinesFile, json);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при записи файла {_machinesFile}", ex);
            }
        }

        private List<Request> LoadRequestsInternal()
        {
            if (!File.Exists(_ordersFile))
                return new List<Request>();

            try
            {
                string json = File.ReadAllText(_ordersFile);
                return JsonConvert.DeserializeObject<List<Request>>(json) ?? new List<Request>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации файла {_ordersFile}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при чтении файла {_ordersFile}", ex);
            }
        }

        private void SaveRequestsInternal(List<Request> requests)
        {
            try
            {
                string json = JsonConvert.SerializeObject(requests, _jsonSettings);
                File.WriteAllText(_ordersFile, json);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при записи файла {_ordersFile}", ex);
            }
        }

        protected virtual void OnMachineChanged(MachineChangedEventArgs e)
        {
            MachineChanged?.Invoke(this, e);
        }

        protected virtual void OnRequestCreated(RequestCreatedEventArgs e)
        {
            RequestCreated?.Invoke(this, e);
        }

        #endregion
    }

    /// <summary>
    /// Аргументы события изменения станка
    /// </summary>
    public class MachineChangedEventArgs : EventArgs
    {
        public int MachineId { get; }
        public MachineAction Action { get; }

        public MachineChangedEventArgs(int machineId, MachineAction action)
        {
            MachineId = machineId;
            Action = action;
        }
    }

    /// <summary>
    /// Аргументы события создания заявки
    /// </summary>
    public class RequestCreatedEventArgs : EventArgs
    {
        public int RequestId { get; }
        public int ClientId { get; }

        public RequestCreatedEventArgs(int requestId, int clientId)
        {
            RequestId = requestId;
            ClientId = clientId;
        }
    }

    /// <summary>
    /// Типы действий со станком
    /// </summary>
    public enum MachineAction
    {
        Added,
        Updated,
        Deleted
    }
}