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
    /// Адаптер для работы с мастерами (Master).
    /// Реализует паттерн Adapter для изоляции логики работы с JSON-файлами.
    /// </summary>
    public class MasterAdapter
    {
        private readonly string _mastersFile;
        private readonly string _ordersFile;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly object _fileLock = new object();

        /// <summary>
        /// Событие, возникающее при изменении данных мастеров
        /// </summary>
        public event EventHandler<MasterChangedEventArgs> MasterChanged;

        /// <summary>
        /// Событие, возникающее при назначении мастера на заявку
        /// </summary>
        public event EventHandler<MasterAssignedEventArgs> MasterAssigned;

        /// <summary>
        /// Конструктор с возможностью указать пути к файлам (для тестирования)
        /// </summary>
        public MasterAdapter(string mastersFilePath = "masters.json", string ordersFilePath = "orders.json")
        {
            _mastersFile = mastersFilePath ?? throw new ArgumentNullException(nameof(mastersFilePath));
            _ordersFile = ordersFilePath ?? throw new ArgumentNullException(nameof(ordersFilePath));
            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Возвращает список всех мастеров
        /// </summary>
        public List<Master> GetAllMasters()
        {
            if (!File.Exists(_mastersFile))
                return new List<Master>();

            lock (_fileLock)
            {
                return LoadMastersInternal();
            }
        }

        /// <summary>
        /// Асинхронно возвращает список всех мастеров
        /// </summary>
        public async Task<List<Master>> GetAllMastersAsync()
        {
            return await Task.Run(() => GetAllMasters());
        }

        /// <summary>
        /// Возвращает список всех мастеров в формате JSON (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте GetAllMasters()")]
        public string FetchMasters()
        {
            var masters = GetAllMasters();
            return JsonConvert.SerializeObject(masters, _jsonSettings);
        }

        /// <summary>
        /// Возвращает мастера по ID
        /// </summary>
        public Master GetMasterById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID мастера должен быть больше 0", nameof(id));

            var masters = GetAllMasters();
            return masters.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Возвращает мастера по email
        /// </summary>
        public Master GetMasterByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email не может быть пустым", nameof(email));

            var masters = GetAllMasters();
            return masters.FirstOrDefault(m => m.Email?.Equals(email, StringComparison.OrdinalIgnoreCase) == true);
        }

        /// <summary>
        /// Добавляет нового мастера
        /// </summary>
        /// <returns>ID добавленного мастера</returns>
        public int AddMaster(Master master)
        {
            if (master == null)
                throw new ArgumentNullException(nameof(master));

            if (string.IsNullOrWhiteSpace(master.Name))
                throw new ArgumentException("Имя мастера не может быть пустым", nameof(master));

            lock (_fileLock)
            {
                var masters = LoadMastersInternal();

                // Проверка на дубликат по email
                if (!string.IsNullOrWhiteSpace(master.Email) &&
                    masters.Any(m => m.Email?.Equals(master.Email, StringComparison.OrdinalIgnoreCase) == true))
                {
                    throw new InvalidOperationException($"Мастер с email '{master.Email}' уже существует");
                }

                // Генерация нового ID
                master.Id = masters.Count > 0 ? masters.Max(m => m.Id) + 1 : 1;
                masters.Add(master);

                SaveMastersInternal(masters);
                OnMasterChanged(new MasterChangedEventArgs(master.Id, MasterAction.Added));

                return master.Id;
            }
        }

        /// <summary>
        /// Добавляет мастера из JSON-строки (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте AddMaster(Master master)")]
        public void PostMaster(string masterJson)
        {
            if (string.IsNullOrWhiteSpace(masterJson))
                throw new ArgumentException("JSON мастера не может быть пустым", nameof(masterJson));

            var master = JsonConvert.DeserializeObject<Master>(masterJson);
            AddMaster(master);
        }

        /// <summary>
        /// Обновляет данные мастера
        /// </summary>
        public bool UpdateMaster(Master updatedMaster)
        {
            if (updatedMaster == null)
                throw new ArgumentNullException(nameof(updatedMaster));

            if (updatedMaster.Id <= 0)
                throw new ArgumentException("ID мастера должен быть больше 0", nameof(updatedMaster));

            lock (_fileLock)
            {
                var masters = LoadMastersInternal();
                var existing = masters.FirstOrDefault(m => m.Id == updatedMaster.Id);

                if (existing == null)
                    return false;

                existing.Name = updatedMaster.Name;
                existing.Email = updatedMaster.Email;
                existing.Phone = updatedMaster.Phone;

                SaveMastersInternal(masters);
                OnMasterChanged(new MasterChangedEventArgs(updatedMaster.Id, MasterAction.Updated));

                return true;
            }
        }

        /// <summary>
        /// Удаляет мастера по ID
        /// </summary>
        public bool DeleteMaster(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID мастера должен быть больше 0", nameof(id));

            lock (_fileLock)
            {
                var masters = LoadMastersInternal();
                var master = masters.FirstOrDefault(m => m.Id == id);

                if (master == null)
                    return false;

                masters.Remove(master);
                SaveMastersInternal(masters);
                OnMasterChanged(new MasterChangedEventArgs(id, MasterAction.Deleted));

                return true;
            }
        }

        /// <summary>
        /// Назначает мастера на заявку
        /// </summary>
        /// <param name="requestId">ID заявки</param>
        /// <param name="masterId">ID мастера</param>
        /// <returns>true, если назначение успешно</returns>
        public bool AssignMasterToRequest(int requestId, int masterId)
        {
            if (requestId <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(requestId));

            if (masterId <= 0)
                throw new ArgumentException("ID мастера должен быть больше 0", nameof(masterId));

            // Проверяем, существует ли мастер
            var master = GetMasterById(masterId);
            if (master == null)
                throw new InvalidOperationException($"Мастер с ID {masterId} не найден");

            lock (_fileLock)
            {
                if (!File.Exists(_ordersFile))
                    return false;

                var requests = LoadRequestsInternal();
                var request = requests.FirstOrDefault(r => r.Id == requestId);

                if (request == null)
                    return false;

                request.MasterId = masterId;
                request.Status = "Назначен мастер";

                SaveRequestsInternal(requests);
                OnMasterAssigned(new MasterAssignedEventArgs(requestId, masterId, master.Name));

                return true;
            }
        }

        /// <summary>
        /// Назначает мастера из JSON-строки (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте AssignMasterToRequest(int requestId, int masterId)")]
        public void PostAssignMaster(string assignJson)
        {
            if (string.IsNullOrWhiteSpace(assignJson))
                throw new ArgumentException("JSON назначения не может быть пустым", nameof(assignJson));

            dynamic data = JsonConvert.DeserializeObject(assignJson);
            int requestId = data.requestId;
            int masterId = data.masterId;

            AssignMasterToRequest(requestId, masterId);
        }

        /// <summary>
        /// Возвращает всех мастеров, отсортированных по имени
        /// </summary>
        public List<Master> GetMastersSortedByName()
        {
            return GetAllMasters().OrderBy(m => m.Name).ToList();
        }

        /// <summary>
        /// Проверяет, существует ли мастер с указанным ID
        /// </summary>
        public bool MasterExists(int id)
        {
            return GetMasterById(id) != null;
        }

        /// <summary>
        /// Возвращает количество мастеров
        /// </summary>
        public int GetMastersCount()
        {
            return GetAllMasters().Count;
        }

        /// <summary>
        /// Удаляет всех мастеров (для тестирования)
        /// </summary>
        public void ClearAllMasters()
        {
            lock (_fileLock)
            {
                if (File.Exists(_mastersFile))
                {
                    File.Delete(_mastersFile);
                }
            }
        }

        #region Private Methods

        private List<Master> LoadMastersInternal()
        {
            if (!File.Exists(_mastersFile))
                return new List<Master>();

            try
            {
                string json = File.ReadAllText(_mastersFile);
                return JsonConvert.DeserializeObject<List<Master>>(json) ?? new List<Master>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации файла {_mastersFile}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при чтении файла {_mastersFile}", ex);
            }
        }

        private void SaveMastersInternal(List<Master> masters)
        {
            try
            {
                string json = JsonConvert.SerializeObject(masters, _jsonSettings);
                File.WriteAllText(_mastersFile, json);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при записи файла {_mastersFile}", ex);
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

        protected virtual void OnMasterChanged(MasterChangedEventArgs e)
        {
            MasterChanged?.Invoke(this, e);
        }

        protected virtual void OnMasterAssigned(MasterAssignedEventArgs e)
        {
            MasterAssigned?.Invoke(this, e);
        }

        #endregion
    }

    /// <summary>
    /// Аргументы события изменения мастера
    /// </summary>
    public class MasterChangedEventArgs : EventArgs
    {
        public int MasterId { get; }
        public MasterAction Action { get; }

        public MasterChangedEventArgs(int masterId, MasterAction action)
        {
            MasterId = masterId;
            Action = action;
        }
    }

    /// <summary>
    /// Аргументы события назначения мастера
    /// </summary>
    public class MasterAssignedEventArgs : EventArgs
    {
        public int RequestId { get; }
        public int MasterId { get; }
        public string MasterName { get; }

        public MasterAssignedEventArgs(int requestId, int masterId, string masterName)
        {
            RequestId = requestId;
            MasterId = masterId;
            MasterName = masterName;
        }
    }

    /// <summary>
    /// Типы действий с мастером
    /// </summary>
    public enum MasterAction
    {
        Added,
        Updated,
        Deleted
    }
}