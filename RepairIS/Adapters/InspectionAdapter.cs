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
    /// Адаптер для работы с осмотрами (Inspection).
    /// Реализует паттерн Adapter для изоляции логики работы с JSON-файлами.
    /// </summary>
    public class InspectionAdapter
    {
        private readonly string _inspectionsFile;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly object _fileLock = new object();

        /// <summary>
        /// Событие, возникающее при изменении данных осмотра
        /// </summary>
        public event EventHandler<InspectionChangedEventArgs> InspectionChanged;

        /// <summary>
        /// Конструктор с возможностью указать путь к файлу (для тестирования)
        /// </summary>
        /// <param name="inspectionsFilePath">Путь к файлу с осмотрами. По умолчанию "inspections.json"</param>
        public InspectionAdapter(string inspectionsFilePath = "inspections.json")
        {
            _inspectionsFile = inspectionsFilePath ?? throw new ArgumentNullException(nameof(inspectionsFilePath));
            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Возвращает осмотр по указанному RequestId
        /// </summary>
        /// <param name="requestId">ID заявки</param>
        /// <returns>Осмотр или null, если не найден</returns>
        public Inspection GetInspectionByRequestId(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            if (!File.Exists(_inspectionsFile))
                return null;

            lock (_fileLock)
            {
                var inspections = LoadInspectionsInternal();
                return inspections.FirstOrDefault(i => i.RequestId == requestId);
            }
        }

        /// <summary>
        /// Асинхронно возвращает осмотр по указанному RequestId
        /// </summary>
        public async Task<Inspection> GetInspectionByRequestIdAsync(int requestId)
        {
            return await Task.Run(() => GetInspectionByRequestId(requestId));
        }

        /// <summary>
        /// Возвращает осмотр в формате JSON (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте GetInspectionByRequestId(int requestId)")]
        public string FetchInspection(int requestId)
        {
            var inspection = GetInspectionByRequestId(requestId);
            return JsonConvert.SerializeObject(inspection, _jsonSettings);
        }

        /// <summary>
        /// Сохраняет новый осмотр
        /// </summary>
        /// <param name="inspection">Объект осмотра</param>
        /// <returns>ID сохраненного осмотра</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если inspection == null</exception>
        public int SaveInspection(Inspection inspection)
        {
            if (inspection == null)
                throw new ArgumentNullException(nameof(inspection));

            if (inspection.RequestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(inspection));

            if (string.IsNullOrWhiteSpace(inspection.Description))
                throw new ArgumentException("Описание осмотра не может быть пустым", nameof(inspection));

            lock (_fileLock)
            {
                var inspections = LoadInspectionsInternal();

                // Проверяем, существует ли уже осмотр для этой заявки
                var existing = inspections.FirstOrDefault(i => i.RequestId == inspection.RequestId);
                if (existing != null)
                {
                    // Обновляем существующий осмотр
                    existing.Description = inspection.Description;
                    existing.WorkRequired = inspection.WorkRequired;
                    existing.PartsNeeded = inspection.PartsNeeded;
                    existing.LaborHours = inspection.LaborHours;
                    existing.EstimatedCost = inspection.EstimatedCost;
                    existing.InspectionDate = DateTime.Now;

                    SaveInspectionsInternal(inspections);
                    OnInspectionChanged(new InspectionChangedEventArgs(inspection.RequestId, InspectionAction.Updated));

                    return existing.Id;
                }

                // Создаем новый осмотр
                inspection.Id = inspections.Count > 0 ? inspections.Max(i => i.Id) + 1 : 1;
                inspection.InspectionDate = DateTime.Now;
                inspections.Add(inspection);

                SaveInspectionsInternal(inspections);
                OnInspectionChanged(new InspectionChangedEventArgs(inspection.RequestId, InspectionAction.Created));

                return inspection.Id;
            }
        }

        /// <summary>
        /// Сохраняет осмотр из JSON-строки (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте SaveInspection(Inspection inspection)")]
        public void PostInspection(string inspectionJson)
        {
            if (string.IsNullOrWhiteSpace(inspectionJson))
                throw new ArgumentException("JSON осмотра не может быть пустым", nameof(inspectionJson));

            var inspection = JsonConvert.DeserializeObject<Inspection>(inspectionJson);
            SaveInspection(inspection);
        }

        /// <summary>
        /// Возвращает все осмотры
        /// </summary>
        public List<Inspection> GetAllInspections()
        {
            if (!File.Exists(_inspectionsFile))
                return new List<Inspection>();

            lock (_fileLock)
            {
                return LoadInspectionsInternal();
            }
        }

        /// <summary>
        /// Возвращает осмотры для указанного мастера (по заявкам, где он назначен)
        /// </summary>
        /// <param name="masterId">ID мастера</param>
        /// <param name="requestAdapter">Адаптер заявок для получения связи мастер-заявка</param>
        public List<Inspection> GetInspectionsByMasterId(int masterId, RequestAdapter requestAdapter)
        {
            if (masterId <= 0)
                throw new ArgumentException("MasterId должен быть больше 0", nameof(masterId));

            if (requestAdapter == null)
                throw new ArgumentNullException(nameof(requestAdapter));

            var masterRequests = requestAdapter.GetRequestsByMasterId(masterId);
            var masterRequestIds = masterRequests.Select(r => r.Id).ToList();

            return GetAllInspections()
                .Where(i => masterRequestIds.Contains(i.RequestId))
                .ToList();
        }

        /// <summary>
        /// Возвращает осмотры для указанного клиента
        /// </summary>
        public List<Inspection> GetInspectionsByClientId(int clientId, RequestAdapter requestAdapter)
        {
            if (clientId <= 0)
                throw new ArgumentException("ClientId должен быть больше 0", nameof(clientId));

            if (requestAdapter == null)
                throw new ArgumentNullException(nameof(requestAdapter));

            var clientRequests = requestAdapter.GetRequestsByClientId(clientId);
            var clientRequestIds = clientRequests.Select(r => r.Id).ToList();

            return GetAllInspections()
                .Where(i => clientRequestIds.Contains(i.RequestId))
                .ToList();
        }

        /// <summary>
        /// Проверяет, существует ли осмотр для указанной заявки
        /// </summary>
        public bool InspectionExists(int requestId)
        {
            return GetInspectionByRequestId(requestId) != null;
        }

        /// <summary>
        /// Удаляет осмотр по RequestId
        /// </summary>
        /// <returns>true, если осмотр найден и удален</returns>
        public bool DeleteInspection(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            lock (_fileLock)
            {
                if (!File.Exists(_inspectionsFile))
                    return false;

                var inspections = LoadInspectionsInternal();
                var inspection = inspections.FirstOrDefault(i => i.RequestId == requestId);

                if (inspection == null)
                    return false;

                inspections.Remove(inspection);
                SaveInspectionsInternal(inspections);

                OnInspectionChanged(new InspectionChangedEventArgs(requestId, InspectionAction.Deleted));
                return true;
            }
        }

        /// <summary>
        /// Обновляет стоимость и трудоемкость осмотра
        /// </summary>
        public bool UpdateInspectionCosts(int requestId, float estimatedCost, float laborHours)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            lock (_fileLock)
            {
                var inspection = GetInspectionByRequestId(requestId);
                if (inspection == null)
                    return false;

                inspection.EstimatedCost = estimatedCost;
                inspection.LaborHours = laborHours;

                var inspections = LoadInspectionsInternal();
                SaveInspectionsInternal(inspections);

                OnInspectionChanged(new InspectionChangedEventArgs(requestId, InspectionAction.Updated));
                return true;
            }
        }

        /// <summary>
        /// Удаляет все осмотры (для тестирования)
        /// </summary>
        public void ClearAllInspections()
        {
            lock (_fileLock)
            {
                if (File.Exists(_inspectionsFile))
                {
                    File.Delete(_inspectionsFile);
                }
            }
        }

        #region Private Methods

        /// <summary>
        /// Загружает все осмотры из файла
        /// </summary>
        private List<Inspection> LoadInspectionsInternal()
        {
            if (!File.Exists(_inspectionsFile))
                return new List<Inspection>();

            try
            {
                string json = File.ReadAllText(_inspectionsFile);
                return JsonConvert.DeserializeObject<List<Inspection>>(json) ?? new List<Inspection>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации файла {_inspectionsFile}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при чтении файла {_inspectionsFile}", ex);
            }
        }

        /// <summary>
        /// Сохраняет осмотры в файл
        /// </summary>
        private void SaveInspectionsInternal(List<Inspection> inspections)
        {
            try
            {
                string json = JsonConvert.SerializeObject(inspections, _jsonSettings);
                File.WriteAllText(_inspectionsFile, json);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при записи файла {_inspectionsFile}", ex);
            }
        }

        /// <summary>
        /// Вызывает событие InspectionChanged
        /// </summary>
        protected virtual void OnInspectionChanged(InspectionChangedEventArgs e)
        {
            InspectionChanged?.Invoke(this, e);
        }

        #endregion
    }

    /// <summary>
    /// Аргументы события изменения осмотра
    /// </summary>
    public class InspectionChangedEventArgs : EventArgs
    {
        public int RequestId { get; }
        public InspectionAction Action { get; }

        public InspectionChangedEventArgs(int requestId, InspectionAction action)
        {
            RequestId = requestId;
            Action = action;
        }
    }

    /// <summary>
    /// Типы действий с осмотром
    /// </summary>
    public enum InspectionAction
    {
        Created,
        Updated,
        Deleted
    }
}