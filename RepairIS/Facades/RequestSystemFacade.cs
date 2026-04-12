using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RepairIS.Adapters;
using RepairIS.Models;

namespace RepairIS.Facades
{
    /// <summary>
    /// Фасад для работы с информационной системой ремонтного предприятия.
    /// Предоставляет унифицированный интерфейс для всех внешних взаимодействий.
    /// </summary>
    public class RequestSystemFacade
    {
        private readonly OrderAdapter _orderAdapter;
        private readonly RequestAdapter _requestAdapter;
        private readonly InspectionAdapter _inspectionAdapter;
        private readonly EstimateAdapter _estimateAdapter;
        private readonly MasterAdapter _masterAdapter;

        /// <summary>
        /// События для уведомления UI об изменениях
        /// </summary>
        public event EventHandler<RequestStatusChangedEventArgs> RequestStatusChanged;
        public event EventHandler<EstimateConfirmedEventArgs> EstimateConfirmed;
        public event EventHandler<MasterAssignedEventArgs> MasterAssigned;

        /// <summary>
        /// Конструктор с возможностью внедрения зависимостей (для тестирования)
        /// </summary>
        public RequestSystemFacade(
            OrderAdapter orderAdapter = null,
            RequestAdapter requestAdapter = null,
            InspectionAdapter inspectionAdapter = null,
            EstimateAdapter estimateAdapter = null,
            MasterAdapter masterAdapter = null)
        {
            _orderAdapter = orderAdapter ?? new OrderAdapter();
            _requestAdapter = requestAdapter ?? new RequestAdapter();
            _inspectionAdapter = inspectionAdapter ?? new InspectionAdapter();
            _estimateAdapter = estimateAdapter ?? new EstimateAdapter();
            _masterAdapter = masterAdapter ?? new MasterAdapter();

            // Подписываемся на события адаптеров
            SubscribeToAdapterEvents();
        }

        private void SubscribeToAdapterEvents()
        {
            _requestAdapter.StatusChanged += (s, e) =>
                RequestStatusChanged?.Invoke(this, e);

            _masterAdapter.MasterAssigned += (s, e) =>
                MasterAssigned?.Invoke(this, e);
        }

        #region OrderAdapter Methods (Станки и заявки)

        /// <summary>
        /// Получает все единицы техники пользователя по его userId
        /// </summary>
        public List<Machine> GetMachines(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("UserId должен быть больше 0", nameof(userId));

            return _orderAdapter.GetMachinesByOwnerId(userId);
        }

        /// <summary>
        /// Получает конкретную единицу техники по её Id
        /// </summary>
        public Machine GetMachine(int machineId)
        {
            if (machineId <= 0)
                throw new ArgumentException("MachineId должен быть больше 0", nameof(machineId));

            return _orderAdapter.GetMachineById(machineId);
        }

        /// <summary>
        /// Создаёт новую заявку на ремонт
        /// </summary>
        /// <returns>ID созданной заявки</returns>
        public int CreateOrder(Request request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return _orderAdapter.CreateRequest(request);
        }

        /// <summary>
        /// Создаёт новую заявку из JSON (для обратной совместимости)
        /// </summary>
        public void CreateOrder(string orderJson)
        {
            if (string.IsNullOrWhiteSpace(orderJson))
                throw new ArgumentException("JSON заявки не может быть пустым", nameof(orderJson));

            _orderAdapter.PostOrder(orderJson);
        }

        /// <summary>
        /// Сохраняет новую единицу техники
        /// </summary>
        /// <returns>ID сохраненного станка</returns>
        public int SaveMachine(Machine machine)
        {
            if (machine == null)
                throw new ArgumentNullException(nameof(machine));

            return _orderAdapter.AddMachine(machine);
        }

        /// <summary>
        /// Сохраняет новую единицу техники из JSON (для обратной совместимости)
        /// </summary>
        public void SaveMachine(string machineJson)
        {
            if (string.IsNullOrWhiteSpace(machineJson))
                throw new ArgumentException("JSON станка не может быть пустым", nameof(machineJson));

            _orderAdapter.PostMachine(machineJson);
        }

        /// <summary>
        /// Обновляет данные станка
        /// </summary>
        public bool UpdateMachine(Machine machine)
        {
            return _orderAdapter.UpdateMachine(machine);
        }

        /// <summary>
        /// Удаляет станок
        /// </summary>
        public bool DeleteMachine(int machineId)
        {
            return _orderAdapter.DeleteMachine(machineId);
        }

        #endregion

        #region RequestAdapter Methods (Заявки)

        /// <summary>
        /// Получает заявку по её Id
        /// </summary>
        public Request GetRequest(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(id));

            return _requestAdapter.GetRequestById(id);
        }

        /// <summary>
        /// Получает список всех заявок
        /// </summary>
        public List<Request> GetAllRequests()
        {
            return _requestAdapter.GetAllRequests();
        }

        /// <summary>
        /// Получает заявки клиента
        /// </summary>
        public List<Request> GetRequestsByClientId(int clientId)
        {
            return _requestAdapter.GetRequestsByClientId(clientId);
        }

        /// <summary>
        /// Получает заявки мастера
        /// </summary>
        public List<Request> GetRequestsByMasterId(int masterId)
        {
            return _requestAdapter.GetRequestsByMasterId(masterId);
        }

        /// <summary>
        /// Получает заявки по статусу
        /// </summary>
        public List<Request> GetRequestsByStatus(string status)
        {
            return _requestAdapter.GetRequestsByStatus(status);
        }

        /// <summary>
        /// Получает заявки, ожидающие обработки
        /// </summary>
        public List<Request> GetPendingRequests()
        {
            return _requestAdapter.GetPendingRequests();
        }

        /// <summary>
        /// Изменяет статус заявки
        /// </summary>
        public bool ChangeStatus(int id, string status)
        {
            return _requestAdapter.UpdateStatus(id, status);
        }

        /// <summary>
        /// Возвращает словарь с историей изменений статусов для всех заявок
        /// </summary>
        public Dictionary<int, List<StatusHistoryEntry>> GetStatusHistory()
        {
            return _requestAdapter.GetStatusHistory();
        }

        /// <summary>
        /// Возвращает историю статусов для конкретной заявки
        /// </summary>
        public List<StatusHistoryEntry> GetStatusHistoryForRequest(int requestId)
        {
            return _requestAdapter.GetStatusHistoryForRequest(requestId);
        }

        /// <summary>
        /// Удаляет заявку
        /// </summary>
        public bool DeleteRequest(int requestId)
        {
            return _requestAdapter.DeleteRequest(requestId);
        }

        #endregion

        #region InspectionAdapter Methods (Осмотры)

        /// <summary>
        /// Получает данные осмотра по Id заявки
        /// </summary>
        public Inspection GetInspection(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            return _inspectionAdapter.GetInspectionByRequestId(requestId);
        }

        /// <summary>
        /// Сохраняет данные осмотра
        /// </summary>
        /// <returns>ID сохраненного осмотра</returns>
        public int SaveInspection(Inspection inspection)
        {
            if (inspection == null)
                throw new ArgumentNullException(nameof(inspection));

            return _inspectionAdapter.SaveInspection(inspection);
        }

        /// <summary>
        /// Сохраняет данные осмотра (старая сигнатура для совместимости)
        /// </summary>
        public void SaveInspection(int id, Inspection inspection)
        {
            SaveInspection(inspection);
        }

        /// <summary>
        /// Проверяет, был ли уже проведен осмотр для заявки
        /// </summary>
        public bool HasInspection(int requestId)
        {
            return _inspectionAdapter.InspectionExists(requestId);
        }

        #endregion

        #region EstimateAdapter Methods (Сметы)

        /// <summary>
        /// Получает смету по Id заявки
        /// </summary>
        public Estimate GetEstimate(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            return _estimateAdapter.GetEstimateByRequestId(requestId);
        }

        /// <summary>
        /// Сохраняет смету
        /// </summary>
        /// <returns>ID сохраненной сметы</returns>
        public int SaveEstimate(Estimate estimate)
        {
            if (estimate == null)
                throw new ArgumentNullException(nameof(estimate));

            return _estimateAdapter.SaveEstimate(estimate);
        }

        /// <summary>
        /// Сохраняет смету (старая сигнатура для совместимости)
        /// </summary>
        public void SaveEstimate(int id, Estimate estimate)
        {
            SaveEstimate(estimate);
        }

        /// <summary>
        /// Подтверждает смету и автоматически обновляет статус заявки
        /// </summary>
        public bool ConfirmEstimate(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            var result = _estimateAdapter.ConfirmEstimate(requestId);
            if (result)
            {
                ChangeStatus(requestId, "Смета подтверждена");
                EstimateConfirmed?.Invoke(this, new EstimateConfirmedEventArgs(requestId));
            }
            return result;
        }

        /// <summary>
        /// Отклоняет смету и автоматически обновляет статус заявки
        /// </summary>
        public bool RejectEstimate(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            var result = _estimateAdapter.RejectEstimate(requestId);
            if (result)
            {
                ChangeStatus(requestId, "Смета отклонена");
            }
            return result;
        }

        /// <summary>
        /// Проверяет, существует ли смета для заявки
        /// </summary>
        public bool HasEstimate(int requestId)
        {
            return _estimateAdapter.EstimateExists(requestId);
        }

        #endregion

        #region MasterAdapter Methods (Мастера)

        /// <summary>
        /// Получает список всех мастеров
        /// </summary>
        public List<Master> GetMasters()
        {
            return _masterAdapter.GetAllMasters();
        }

        /// <summary>
        /// Получает мастера по ID
        /// </summary>
        public Master GetMasterById(int masterId)
        {
            return _masterAdapter.GetMasterById(masterId);
        }

        /// <summary>
        /// Назначает мастера на заявку
        /// </summary>
        public bool AssignMaster(int requestId, int masterId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));
            if (masterId <= 0)
                throw new ArgumentException("MasterId должен быть больше 0", nameof(masterId));

            return _masterAdapter.AssignMasterToRequest(requestId, masterId);
        }

        /// <summary>
        /// Сохраняет нового мастера
        /// </summary>
        /// <returns>ID сохраненного мастера</returns>
        public int SaveMaster(Master master)
        {
            if (master == null)
                throw new ArgumentNullException(nameof(master));

            return _masterAdapter.AddMaster(master);
        }

        /// <summary>
        /// Обновляет данные мастера
        /// </summary>
        public bool UpdateMaster(Master master)
        {
            return _masterAdapter.UpdateMaster(master);
        }

        /// <summary>
        /// Удаляет мастера
        /// </summary>
        public bool DeleteMaster(int masterId)
        {
            return _masterAdapter.DeleteMaster(masterId);
        }

        #endregion

        #region Комбинированные операции (Бизнес-логика)

        /// <summary>
        /// Полный цикл: осмотр → смета → подтверждение
        /// </summary>
        public bool ProcessInspectionAndEstimate(int requestId, Inspection inspection, Estimate estimate)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            // 1. Сохраняем осмотр
            inspection.RequestId = requestId;
            SaveInspection(inspection);

            // 2. Сохраняем смету
            estimate.RequestId = requestId;
            SaveEstimate(estimate);

            // 3. Меняем статус
            ChangeStatus(requestId, "Смета сформирована");

            return true;
        }

        /// <summary>
        /// Завершение ремонта: завершаем ремонт и выставляем счет
        /// </summary>
        public bool CompleteRepair(int requestId)
        {
            var request = GetRequest(requestId);
            if (request == null)
                return false;

            if (request.Status != "В работе")
                throw new InvalidOperationException($"Нельзя завершить ремонт из статуса {request.Status}");

            return ChangeStatus(requestId, "Завершено");
        }

        /// <summary>
        /// Полная информация по заявке (для отображения)
        /// </summary>
        public RequestFullInfo GetFullRequestInfo(int requestId)
        {
            var request = GetRequest(requestId);
            if (request == null)
                return null;

            return new RequestFullInfo
            {
                Request = request,
                Machine = GetMachine(request.MachineId),
                Master = request.MasterId > 0 ? GetMasterById(request.MasterId) : null,
                Inspection = GetInspection(requestId),
                Estimate = GetEstimate(requestId),
                StatusHistory = GetStatusHistoryForRequest(requestId)
            };
        }

        #endregion
    }

    /// <summary>
    /// Полная информация по заявке
    /// </summary>
    public class RequestFullInfo
    {
        public Request Request { get; set; }
        public Machine Machine { get; set; }
        public Master Master { get; set; }
        public Inspection Inspection { get; set; }
        public Estimate Estimate { get; set; }
        public List<StatusHistoryEntry> StatusHistory { get; set; }
    }

    /// <summary>
    /// Аргументы события подтверждения сметы
    /// </summary>
    public class EstimateConfirmedEventArgs : EventArgs
    {
        public int RequestId { get; }
        public EstimateConfirmedEventArgs(int requestId) => RequestId = requestId;
    }
}