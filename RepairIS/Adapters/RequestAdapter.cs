using Newtonsoft.Json;
using RepairIS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepairIS.Adapters
{
    public class RequestAdapter
    {
        private string requestsFile = "orders.json";
        private string historyFile = "status_history.json";

        // Возвращает заявку по Id в формате JSON, если не найдена или нет файла - "null"
        public string FetchRequest(int id)
        {
            if (!File.Exists(requestsFile))
                return "null";

            var requests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(requestsFile));
            var request = requests.FirstOrDefault(r => r.Id == id);
            return JsonConvert.SerializeObject(request);
        }

        // Возвращает все заявки в формате JSON, если файла нет - "[]"
        public string FetchAllRequests()
        {
            if (!File.Exists(requestsFile))
                return "[]";
            return File.ReadAllText(requestsFile);
        }

        // Обновляет статус заявки и сохраняет историю изменений
        public void UpdateStatus(int id, string status)
        {
            if (!File.Exists(requestsFile))
                return;

            var requests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(requestsFile));
            var request = requests.FirstOrDefault(r => r.Id == id);
            if (request != null)
            {
                string oldStatus = request.Status;
                request.Status = status;
                File.WriteAllText(requestsFile, JsonConvert.SerializeObject(requests, Newtonsoft.Json.Formatting.Indented));

                SaveStatusHistory(id, oldStatus, status);
            }
        }

        // Возвращает словарь истории статусов: ключ - Id заявки, значение - список изменений с датой
        public Dictionary<int, List<string>> GetStatusHistory()
        {
            if (!File.Exists(historyFile))
                return new Dictionary<int, List<string>>();

            string json = File.ReadAllText(historyFile);
            var result = JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(json);
            return result ?? new Dictionary<int, List<string>>();
        }

        // Сохраняет запись об изменении статуса в файл истории
        private void SaveStatusHistory(int requestId, string oldStatus, string newStatus)
        {
            var history = GetStatusHistory();

            if (!history.ContainsKey(requestId))
            {
                history[requestId] = new List<string>();
            }

            history[requestId].Add($"{DateTime.Now}: {oldStatus} → {newStatus}");

            File.WriteAllText(historyFile, JsonConvert.SerializeObject(history, Newtonsoft.Json.Formatting.Indented));
        }
    }
}