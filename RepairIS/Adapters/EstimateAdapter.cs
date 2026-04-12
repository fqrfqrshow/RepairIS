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
    /// Адаптер для работы со сметами (Estimate).
    /// Реализует паттерн Adapter для изоляции логики работы с JSON-файлами.
    /// </summary>
    public class EstimateAdapter
    {
        private readonly string _estimatesFile;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly object _fileLock = new object(); // Для потокобезопасности

        /// <summary>
        /// Событие, возникающее при изменении данных смет
        /// </summary>
        public event EventHandler<EstimateChangedEventArgs> EstimateChanged;

        /// <summary>
        /// Конструктор с возможностью указать путь к файлу (для тестирования)
        /// </summary>
        /// <param name="estimatesFilePath">Путь к файлу со сметами. По умолчанию "estimates.json"</param>
        public EstimateAdapter(string estimatesFilePath = "estimates.json")
        {
            _estimatesFile = estimatesFilePath ?? throw new ArgumentNullException(nameof(estimatesFilePath));
            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Сохраняет новую смету в файл. Если смета с таким RequestId уже существует, она заменяется.
        /// Автоматически присваивает новый Id.
        /// </summary>
        /// <param name="estimate">Объект сметы</param>
        /// <returns>ID сохраненной сметы</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если estimate == null</exception>
        public int SaveEstimate(Estimate estimate)
        {
            if (estimate == null)
                throw new ArgumentNullException(nameof(estimate));

            if (estimate.RequestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(estimate));

            lock (_fileLock)
            {
                var estimates = LoadEstimatesInternal();

                // Удаляем существующую смету для этого RequestId
                var existing = estimates.FirstOrDefault(e => e.RequestId == estimate.RequestId);
                if (existing != null)
                {
                    estimates.Remove(existing);
                }

                // Генерация нового ID
                estimate.Id = estimates.Count > 0 ? estimates.Max(e => e.Id) + 1 : 1;
                estimate.IsConfirmed = false; // Новая смета всегда неподтверждена

                estimates.Add(estimate);
                SaveEstimatesInternal(estimates);

                // Вызываем событие
                OnEstimateChanged(new EstimateChangedEventArgs(estimate.RequestId, EstimateAction.CreatedOrUpdated));

                return estimate.Id;
            }
        }

        /// <summary>
        /// Сохраняет смету из JSON-строки (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте SaveEstimate(Estimate estimate) вместо PostEstimate(string)")]
        public void PostEstimate(string estimateJson)
        {
            if (string.IsNullOrWhiteSpace(estimateJson))
                throw new ArgumentException("JSON сметы не может быть пустым", nameof(estimateJson));

            var estimate = JsonConvert.DeserializeObject<Estimate>(estimateJson);
            SaveEstimate(estimate);
        }

        /// <summary>
        /// Возвращает смету по указанному RequestId
        /// </summary>
        /// <param name="requestId">ID заявки</param>
        /// <returns>Смета или null, если не найдена</returns>
        public Estimate GetEstimateByRequestId(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            if (!File.Exists(_estimatesFile))
                return null;

            lock (_fileLock)
            {
                var estimates = LoadEstimatesInternal();
                return estimates.FirstOrDefault(e => e.RequestId == requestId);
            }
        }

        /// <summary>
        /// Асинхронно возвращает смету по указанному RequestId
        /// </summary>
        public async Task<Estimate> GetEstimateByRequestIdAsync(int requestId)
        {
            return await Task.Run(() => GetEstimateByRequestId(requestId));
        }

        /// <summary>
        /// Возвращает смету в формате JSON (для обратной совместимости)
        /// </summary>
        [Obsolete("Используйте GetEstimateByRequestId(int requestId)")]
        public string FetchEstimate(int requestId)
        {
            var estimate = GetEstimateByRequestId(requestId);
            return JsonConvert.SerializeObject(estimate, _jsonSettings);
        }

        /// <summary>
        /// Возвращает все сметы
        /// </summary>
        public List<Estimate> GetAllEstimates()
        {
            if (!File.Exists(_estimatesFile))
                return new List<Estimate>();

            lock (_fileLock)
            {
                return LoadEstimatesInternal();
            }
        }

        /// <summary>
        /// Возвращает все подтвержденные сметы
        /// </summary>
        public List<Estimate> GetConfirmedEstimates()
        {
            return GetAllEstimates().Where(e => e.IsConfirmed).ToList();
        }

        /// <summary>
        /// Подтверждает смету по RequestId (устанавливает IsConfirmed = true)
        /// </summary>
        /// <returns>true, если смета найдена и подтверждена</returns>
        public bool ConfirmEstimate(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            lock (_fileLock)
            {
                if (!File.Exists(_estimatesFile))
                    return false;

                var estimates = LoadEstimatesInternal();
                var estimate = estimates.FirstOrDefault(e => e.RequestId == requestId);

                if (estimate == null)
                    return false;

                if (estimate.IsConfirmed)
                    return true; // Уже подтверждена

                estimate.IsConfirmed = true;
                SaveEstimatesInternal(estimates);

                OnEstimateChanged(new EstimateChangedEventArgs(requestId, EstimateAction.Confirmed));
                return true;
            }
        }

        /// <summary>
        /// Отклоняет смету по RequestId (полностью удаляет её из файла)
        /// </summary>
        /// <returns>true, если смета найдена и удалена</returns>
        public bool RejectEstimate(int requestId)
        {
            if (requestId <= 0)
                throw new ArgumentException("RequestId должен быть больше 0", nameof(requestId));

            lock (_fileLock)
            {
                if (!File.Exists(_estimatesFile))
                    return false;

                var estimates = LoadEstimatesInternal();
                var estimate = estimates.FirstOrDefault(e => e.RequestId == requestId);

                if (estimate == null)
                    return false;

                estimates.Remove(estimate);
                SaveEstimatesInternal(estimates);

                OnEstimateChanged(new EstimateChangedEventArgs(requestId, EstimateAction.Rejected));
                return true;
            }
        }

        /// <summary>
        /// Проверяет, существует ли смета для указанной заявки
        /// </summary>
        public bool EstimateExists(int requestId)
        {
            return GetEstimateByRequestId(requestId) != null;
        }

        /// <summary>
        /// Удаляет все сметы (для тестирования)
        /// </summary>
        public void ClearAllEstimates()
        {
            lock (_fileLock)
            {
                if (File.Exists(_estimatesFile))
                {
                    File.Delete(_estimatesFile);
                }
            }
        }

        #region Private Methods

        /// <summary>
        /// Загружает все сметы из файла
        /// </summary>
        private List<Estimate> LoadEstimatesInternal()
        {
            if (!File.Exists(_estimatesFile))
                return new List<Estimate>();

            try
            {
                string json = File.ReadAllText(_estimatesFile);
                return JsonConvert.DeserializeObject<List<Estimate>>(json) ?? new List<Estimate>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации файла {_estimatesFile}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при чтении файла {_estimatesFile}", ex);
            }
        }

        /// <summary>
        /// Сохраняет сметы в файл
        /// </summary>
        private void SaveEstimatesInternal(List<Estimate> estimates)
        {
            try
            {
                string json = JsonConvert.SerializeObject(estimates, _jsonSettings);
                File.WriteAllText(_estimatesFile, json);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"Ошибка при записи файла {_estimatesFile}", ex);
            }
        }

        /// <summary>
        /// Вызывает событие EstimateChanged
        /// </summary>
        protected virtual void OnEstimateChanged(EstimateChangedEventArgs e)
        {
            EstimateChanged?.Invoke(this, e);
        }

        #endregion
    }

    /// <summary>
    /// Аргументы события изменения сметы
    /// </summary>
    public class EstimateChangedEventArgs : EventArgs
    {
        public int RequestId { get; }
        public EstimateAction Action { get; }

        public EstimateChangedEventArgs(int requestId, EstimateAction action)
        {
            RequestId = requestId;
            Action = action;
        }
    }

    /// <summary>
    /// Типы действий со сметой
    /// </summary>
    public enum EstimateAction
    {
        CreatedOrUpdated,
        Confirmed,
        Rejected
    }
}