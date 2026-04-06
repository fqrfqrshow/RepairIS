using Newtonsoft.Json;
using RepairIS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepairIS.Adapters
{
    public class InspectionAdapter
    {
        private string inspectionsFile = "inspections.json";

        /// <summary>
        /// Возвращает данные осмотра по указанному RequestId в формате JSON.
        /// Если осмотр не найден или файла нет, возвращает "null".
        /// </summary>
        public string FetchInspection(int id)
        {
            if (!File.Exists(inspectionsFile))
                return "null";

            var inspections = JsonConvert.DeserializeObject<List<Inspection>>(File.ReadAllText(inspectionsFile));
            var inspection = inspections.FirstOrDefault(i => i.RequestId == id);
            return JsonConvert.SerializeObject(inspection);
        }

        /// <summary>
        /// Сохраняет новый осмотр в файл. Автоматически присваивает новый Id
        /// и устанавливает текущую дату/время как дату осмотра.
        /// </summary>
        public void PostInspection(string inspectionJson)
        {
            var inspections = new List<Inspection>();
            if (File.Exists(inspectionsFile))
                inspections = JsonConvert.DeserializeObject<List<Inspection>>(File.ReadAllText(inspectionsFile));

            var newInspection = JsonConvert.DeserializeObject<Inspection>(inspectionJson);
            newInspection.Id = inspections.Count > 0 ? inspections.Max(i => i.Id) + 1 : 1;
            newInspection.InspectionDate = DateTime.Now;
            inspections.Add(newInspection);

            File.WriteAllText(inspectionsFile, JsonConvert.SerializeObject(inspections, Newtonsoft.Json.Formatting.Indented));
        }
    }
}