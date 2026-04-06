using Newtonsoft.Json;
using RepairIS.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepairIS.Adapters
{
    public class MasterAdapter
    {
        private string mastersFile = "masters.json";
        private string ordersFile = "orders.json";

        // Возвращает список всех мастеров в формате JSON, если файла нет - возвращает "[]"
        public string FetchMasters()
        {
            if (!File.Exists(mastersFile))
                return "[]";
            return File.ReadAllText(mastersFile);
        }

        // Назначает мастера на заявку: обновляет MasterId и меняет статус на "Назначен мастер"
        public void PostAssignMaster(string assignJson)
        {
            dynamic data = JsonConvert.DeserializeObject(assignJson);
            int requestId = data.requestId;
            int masterId = data.masterId;

            if (!File.Exists(ordersFile))
                return;

            var requests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(ordersFile));
            var request = requests.FirstOrDefault(r => r.Id == requestId);
            if (request != null)
            {
                request.MasterId = masterId;
                request.Status = "Назначен мастер";
                File.WriteAllText(ordersFile, JsonConvert.SerializeObject(requests, Newtonsoft.Json.Formatting.Indented));
            }
        }

        // Добавляет нового мастера в файл, автоматически присваивая новый Id
        public void PostMaster(string masterJson)
        {
            var masters = new List<Master>();
            if (File.Exists(mastersFile))
                masters = JsonConvert.DeserializeObject<List<Master>>(File.ReadAllText(mastersFile));

            var newMaster = JsonConvert.DeserializeObject<Master>(masterJson);
            newMaster.Id = masters.Count > 0 ? masters.Max(m => m.Id) + 1 : 1;
            masters.Add(newMaster);

            File.WriteAllText(mastersFile, JsonConvert.SerializeObject(masters, Newtonsoft.Json.Formatting.Indented));
        }
    }
}