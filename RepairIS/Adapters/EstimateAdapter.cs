using Newtonsoft.Json;
using RepairIS.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepairIS.Adapters
{
    public class EstimateAdapter
    {
        private string estimatesFile = "estimates.json";

        /// <summary>
        /// Сохраняет новую смету в файл. Если смета с таким RequestId уже существует, она заменяется.
        /// Автоматически присваивает новый Id.
        /// </summary>
        public void PostEstimate(string estimateJson)
        {
            var estimates = new List<Estimate>();
            if (File.Exists(estimatesFile))
                estimates = JsonConvert.DeserializeObject<List<Estimate>>(File.ReadAllText(estimatesFile));

            var newEstimate = JsonConvert.DeserializeObject<Estimate>(estimateJson);

            var existing = estimates.FirstOrDefault(e => e.RequestId == newEstimate.RequestId);
            if (existing != null)
            {
                estimates.Remove(existing);
            }

            newEstimate.Id = estimates.Count > 0 ? estimates.Max(e => e.Id) + 1 : 1;
            estimates.Add(newEstimate);

            File.WriteAllText(estimatesFile, JsonConvert.SerializeObject(estimates, Newtonsoft.Json.Formatting.Indented));
        }

        /// <summary>
        /// Возвращает смету по указанному RequestId в формате JSON.
        /// Если смета не найдена или файла нет, возвращает "null".
        /// </summary>
        public string FetchEstimate(int requestId)
        {
            if (!File.Exists(estimatesFile))
                return "null";

            var estimates = JsonConvert.DeserializeObject<List<Estimate>>(File.ReadAllText(estimatesFile));
            var estimate = estimates.FirstOrDefault(e => e.RequestId == requestId);
            return JsonConvert.SerializeObject(estimate);
        }

        /// <summary>
        /// Подтверждает смету по RequestId (устанавливает IsConfirmed = true).
        /// Если смета не найдена или файла нет, ничего не делает.
        /// </summary>
        public void ConfirmEstimate(int requestId)
        {
            if (!File.Exists(estimatesFile))
                return;

            var estimates = JsonConvert.DeserializeObject<List<Estimate>>(File.ReadAllText(estimatesFile));
            var estimate = estimates.FirstOrDefault(e => e.RequestId == requestId);
            if (estimate != null)
            {
                estimate.IsConfirmed = true;
                File.WriteAllText(estimatesFile, JsonConvert.SerializeObject(estimates, Newtonsoft.Json.Formatting.Indented));
            }
        }

        /// <summary>
        /// Отклоняет смету по RequestId (полностью удаляет её из файла).
        /// Если смета не найдена или файла нет, ничего не делает.
        /// </summary>
        public void RejectEstimate(int requestId)
        {
            if (!File.Exists(estimatesFile))
                return;

            var estimates = JsonConvert.DeserializeObject<List<Estimate>>(File.ReadAllText(estimatesFile));
            var estimate = estimates.FirstOrDefault(e => e.RequestId == requestId);
            if (estimate != null)
            {
                estimates.Remove(estimate);
                File.WriteAllText(estimatesFile, JsonConvert.SerializeObject(estimates, Newtonsoft.Json.Formatting.Indented));
            }
        }
    }
}