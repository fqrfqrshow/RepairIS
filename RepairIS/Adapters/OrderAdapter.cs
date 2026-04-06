using Newtonsoft.Json;
using RepairIS.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepairIS.Adapters
{
    public class OrderAdapter
    {
        private string machinesFile = "machines.json";
        private string ordersFile = "orders.json";

        // Возвращает список техники пользователя по OwnerId в формате JSON, если файла нет - "[]"
        public string FetchMachines(int userId)
        {
            if (!File.Exists(machinesFile))
                return "[]";

            var allMachines = JsonConvert.DeserializeObject<List<Machine>>(File.ReadAllText(machinesFile));
            var userMachines = allMachines.Where(m => m.OwnerId == userId).ToList();
            return JsonConvert.SerializeObject(userMachines);
        }

        // Возвращает технику по Id в формате JSON, если не найдена или нет файла - "null"
        public string FetchMachineById(int machineId)
        {
            if (!File.Exists(machinesFile))
                return "null";

            var allMachines = JsonConvert.DeserializeObject<List<Machine>>(File.ReadAllText(machinesFile));
            var machine = allMachines.FirstOrDefault(m => m.Id == machineId);
            return JsonConvert.SerializeObject(machine);
        }

        // Добавляет новую заявку на ремонт, автоматически присваивая новый Id
        public void PostOrder(string orderJson)
        {
            var orders = new List<Request>();
            if (File.Exists(ordersFile))
                orders = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(ordersFile));

            var newOrder = JsonConvert.DeserializeObject<Request>(orderJson);
            newOrder.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
            orders.Add(newOrder);

            File.WriteAllText(ordersFile, JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented));
        }

        // Добавляет новую единицу техники, автоматически присваивая новый Id
        public void PostMachine(string machineJson)
        {
            var machines = new List<Machine>();
            if (File.Exists(machinesFile))
                machines = JsonConvert.DeserializeObject<List<Machine>>(File.ReadAllText(machinesFile));

            var newMachine = JsonConvert.DeserializeObject<Machine>(machineJson);
            newMachine.Id = machines.Count > 0 ? machines.Max(m => m.Id) + 1 : 1;
            machines.Add(newMachine);

            File.WriteAllText(machinesFile, JsonConvert.SerializeObject(machines, Newtonsoft.Json.Formatting.Indented));
        }
    }
}