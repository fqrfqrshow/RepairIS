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
    /// Адаптер для работы с заявками (Request) и историей статусов.
    /// Реализует паттерн Adapter для изоляции логики работы с JSON-файлами.
    /// </summary>
    public class RequestAdapter
    {
        private readonly string _requestsFile;
        private readonly string _historyFile;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly object _fileLock = new object();

        /// <summary>
        /// Событие, возникающее при изменении статуса заявки
        /// </summary>
        public event EventHandler<RequestStatusChangedEventArgs> StatusChanged;

        /// <summary>
        /// Конструктор с возможностью указать пути к файлам (для тестирования)
        /// </summary>
        public RequestAdapter(string requestsFilePath = "orders.json", string historyFilePath = "status_history.json")
        {
            _requestsFile = requestsFilePath ?? throw new ArgumentNullException(nameof(requestsFilePath));
            _historyFile = historyFilePath ?? throw new ArgumentNullException(nameof(historyFilePath));
            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        #region Request Methods

        /// <summary>
        /// Возвращает заявку по ID
        /// </summary>
        public Request GetRequestById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(id));

            if (!File.Exists(_requestsFile))
                return null;

            lock (_fileLock)
            {
                var requests = LoadRequestsInternal();
                return requests.FirstOrDefault(r => r.Id == id);
            }
        }

        /// <summary>
        /// Возвращает заявку по ID в формате JSON
        /// </summary>
        public string FetchRequest(int id)
        {
            var request = GetRequestById(id);
            return JsonConvert.SerializeObject(request, _jsonSettings);
        }

        /// <summary>
        /// Возвращает все заявки
        /// </summary>
        public List<Request> GetAllRequests()
        {
            if (!File.Exists(_requestsFile))
                return new List<Request>();

            lock (_fileLock)
            {
                return LoadRequestsInternal();
            }
        }

        /// <summary>
        /// Возвращает все заявки в формате JSON
        /// </summary>
        public string FetchAllRequests()
        {
            var requests = GetAllRequests();
            return JsonConvert.SerializeObject(requests, _jsonSettings);
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
        /// Возвращает заявки по статусу
        /// </summary>
        public List<Request> GetRequestsByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Статус не может быть пустым", nameof(status));

            var allRequests = GetAllRequests();
            return allRequests.Where(r => r.Status == status).ToList();
        }

        /// <summary>
        /// Возвращает заявки, требующие обработки (статус "Ожидает обработки")
        /// </summary>
        public List<Request> GetPendingRequests()
        {
            return GetRequestsByStatus("Ожидает обработки");
        }

        /// <summary>
        /// Возвращает активные заявки (не завершенные и не отклоненные)
        /// </summary>
        public List<Request> GetActiveRequests()
        {
            var allRequests = GetAllRequests();
            var completedStatuses = new[] { "Завершено", "Оплачено", "Отклонена" };
            return allRequests.Where(r => !completedStatuses.Contains(r.Status)).ToList();
        }

        /// <summary>
        /// Обновляет статус заявки и сохраняет историю изменений
        /// </summary>
        /// <returns>true, если статус успешно обновлен</returns>
        public bool UpdateStatus(int id, string newStatus)
        {
            if (id <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(id));

            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Статус не может быть пустым", nameof(newStatus));

            lock (_fileLock)
            {
                if (!File.Exists(_requestsFile))
                    return false;

                var requests = LoadRequestsInternal();
                var request = requests.FirstOrDefault(r => r.Id == id);

                if (request == null)
                    return false;

                string oldStatus = request.Status;

                // Проверка на валидность перехода статуса
                if (!IsValidStatusTransition(oldStatus, newStatus))
                {
                    throw new InvalidOperationException($"Недопустимый переход статуса: {oldStatus} → {newStatus}");
                }

                request.Status = newStatus;
                SaveRequestsInternal(requests);

                // Сохраняем историю
                SaveStatusHistory(id, oldStatus, newStatus);

                // Вызываем событие
                OnStatusChanged(new RequestStatusChangedEventArgs(id, oldStatus, newStatus));

                return true;
            }
        }

        /// <summary>
        /// Проверяет валидность перехода статуса
        /// </summary>
        private bool IsValidStatusTransition(string oldStatus, string newStatus)
        {
            var validTransitions = new Dictionary<string, string[]>
            {
                { "Ожидает обработки", new[] { "Принята в работу", "Отклонена" } },
                { "Принята в работу", new[] { "Назначен мастер", "Отклонена" } },
                { "Назначен мастер", new[] { "Станок принят", "Отклонена" } },
                { "Станок принят", new[] { "В работе", "Отклонена" } },
                { "В работе", new[] { "Завершено", "Отклонена" } },
                { "Завершено", new[] { "Возвращён", "Оплачено" } },
                { "Возвращён", new[] { "Оплачено" } },
                { "Смета подтверждена", new[] { "В работе", "Отклонена" } },
                { "Смета отклонена", new[] { "Ожидает обработки" } }
            };

            if (!validTransitions.ContainsKey(oldStatus))
                return true; // Если нет правил для старого статуса, разрешаем

            return validTransitions[oldStatus].Contains(newStatus);
        }

        /// <summary>
        /// Обновляет заявку (полностью)
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
        public bool DeleteRequest(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID заявки должен быть больше 0", nameof(id));

            lock (_fileLock)
            {
                var requests = LoadRequestsInternal();
                var request = requests.FirstOrDefault(r => r.Id == id);

                if (request == null)
                    return false;

                requests.Remove(request);
                SaveRequestsInternal(requests);
                return true;
            }
        }

        /// <summary>
        /// Возвращает количество заявок клиента
        /// </summary>
        public int GetClientRequestsCount(int clientId)
        {
            return GetRequestsByClientId(clientId).Count;
        }

        /// <summary>
        /// Возвращает количество активных заявок мастера
        /// </summary>
        public int GetMasterActiveRequestsCount(int masterId)
        {
            var masterRequests = GetRequestsByMasterId(masterId);
            var activeStatuses = new[] { "Назначен мастер", "Станок принят", "В работе" };
            return masterRequests.Count(r => activeStatuses.Contains(r.Status));
        }

        #endregion

        #region History Methods

        /// <summary>
        /// Возвращает историю статусов для всех заявок
        /// </summary>
        public Dictionary<int, List<StatusHistoryEntry>> GetStatusHistory()
        {
            if (!File.Exists(_historyFile))
                return new Dictionary<int, List<StatusHistoryEntry>>();

            lock (_fileLock)
            {
                try
                {
                    string json = File.ReadAllText(_historyFile);
                    return JsonConvert.DeserializeObject<Dictionary<int, List<StatusHistoryEntry>>>(json)
                           ?? new Dictionary<int, List<StatusHistoryEntry>>();
                }
                catch (JsonException ex)
                {
                    throw new InvalidOperationException($"Ошибка при десериализации файла {_historyFile}", ex);
                }
            }
        }

        /// <summary>
        /// Возвращает историю статусов для конкретной заявки
        /// </summary>
        public List<StatusHistoryEntry> GetStatusHistoryForRequest(int requestId)
        {
            var history = GetStatusHistory();
            return history.ContainsKey(requestId) ? history[requestId] : new List<StatusHistoryEntry>();
        }

        /// <summary>
        /// Сохраняет запись об изменении статуса
        /// </summary>
        private void SaveStatusHistory(int requestId, string oldStatus, string newStatus)
        {
            lock (_fileLock)
            {
                var history = GetStatusHistory();

                if (!history.ContainsKey(requestId))
                {
                    history[requestId] = new List<StatusHistoryEntry>();
                }

                history[requestId].Add(new StatusHistoryEntry
                {
                    Timestamp = DateTime.Now,
                    OldStatus = oldStatus,
                    NewStatus = newStatus
                });

                try
                {
                    string json = JsonConvert.SerializeObject(history, _jsonSettings);
                    File.WriteAllText(_historyFile, json);
                }
                catch (IOException ex)
                {
                    throw new InvalidOperationException($"Ошибка при записи файла {_historyFile}", ex);
                }
            }
        }

        /// <summary>
        /// Очищает историю статусов (для тестирования)
        /// </summary>
        public void ClearHistory()
        {
            lock (_fileLock)
            {
                if (File.Exists(_historyFile))
                {
                    File.Delete(_historyFile);
                }
            }
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Удаляет все заявки (для тестирования)
        /// </summary>
        public void ClearAllRequests()
        {
            lock (_fileLock)
            {
                if (File.Exists(_requestsFile))
                {
                    File.Delete(_requestsFile);
                }
            }
        }

        #endregion

        #region Private Methods

        private List<Request> LoadRequestsInternal()
        {
            if (!File.Exists(_requestsFile))
                return new List<Request>();

            try
            {
                string json = File.ReadAllText(_requestsFile);
                return JsonConvert.DeserializeObject<List<Request>>(json) ?? new List<Request>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации файла {_requestsFile}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при чтении файла {_requestsFile}", ex);
            }
        }

        private void SaveRequestsInternal(List<Request> requests)
        {
            try
            {
                string json = JsonConvert.SerializeObject(requests, _jsonSettings);
                File.WriteAllText(_requestsFile, json);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при записи файла {_requestsFile}", ex);
            }
        }

        protected virtual void OnStatusChanged(RequestStatusChangedEventArgs e)
        {
            StatusChanged?.Invoke(this, e);
        }

        #endregion
    }

    /// <summary>
    /// Запись истории изменения статуса
    /// </summary>
    public class StatusHistoryEntry
    {
        public DateTime Timestamp { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }

        public override string ToString()
        {
            return $"{Timestamp:yyyy-MM-dd HH:mm:ss}: {OldStatus} → {NewStatus}";
        }
    }

    /// <summary>
    /// Аргументы события изменения статуса заявки
    /// </summary>
    public class RequestStatusChangedEventArgs : EventArgs
    {
        public int RequestId { get; }
        public string OldStatus { get; }
        public string NewStatus { get; }

        public RequestStatusChangedEventArgs(int requestId, string oldStatus, string newStatus)
        {
            RequestId = requestId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}