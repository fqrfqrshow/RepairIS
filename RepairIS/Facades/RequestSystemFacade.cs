using System.Collections.Generic;
using Newtonsoft.Json;
using RepairIS.Adapters;
using RepairIS.Models;

namespace RepairIS.Facades
{
    public class RequestSystemFacade
    {
        private OrderAdapter orderAdapter = new OrderAdapter();
        private RequestAdapter requestAdapter = new RequestAdapter();
        private InspectionAdapter inspectionAdapter = new InspectionAdapter();
        private EstimateAdapter estimateAdapter = new EstimateAdapter();
        private MasterAdapter masterAdapter = new MasterAdapter();

        // ========== OrderAdapter методы ==========

        // Получает все единицы техники пользователя по его userId
        // Десериализует JSON в список объектов Machine, при null возвращает пустой список
        public List<Machine> GetMachines(int userId)
        {
            string json = orderAdapter.FetchMachines(userId);
            return JsonConvert.DeserializeObject<List<Machine>>(json) ?? new List<Machine>();
        }

        // Получает конкретную единицу техники по её Id
        // Десериализует JSON в объект Machine
        public Machine GetMachine(int machineId)
        {
            string json = orderAdapter.FetchMachineById(machineId);
            return JsonConvert.DeserializeObject<Machine>(json);
        }

        // Создаёт новую заявку на ремонт, принимая JSON с данными заказа
        public void CreateOrder(string orderJson)
        {
            orderAdapter.PostOrder(orderJson);
        }

        // Сохраняет новую единицу техники, принимая JSON с данными машины
        public void SaveMachine(string machineJson)
        {
            orderAdapter.PostMachine(machineJson);
        }

        // ========== RequestAdapter методы ==========

        // Получает заявку по её Id, десериализует JSON в объект Request
        public Request GetRequest(int id)
        {
            string json = requestAdapter.FetchRequest(id);
            return JsonConvert.DeserializeObject<Request>(json);
        }

        // Получает список всех заявок, десериализует JSON в список Request
        // При null возвращает пустой список
        public List<Request> GetAllRequests()
        {
            string json = requestAdapter.FetchAllRequests();
            return JsonConvert.DeserializeObject<List<Request>>(json) ?? new List<Request>();
        }

        // Изменяет статус заявки (например: "Новая" → "В работе")
        public void ChangeStatus(int id, string status)
        {
            requestAdapter.UpdateStatus(id, status);
        }

        // Возвращает словарь с историей изменений статусов для всех заявок
        // Ключ - Id заявки, значение - список строк с изменениями и датами
        public Dictionary<int, List<string>> GetStatusHistory()
        {
            return requestAdapter.GetStatusHistory();
        }

        // ========== InspectionAdapter методы ==========

        // Получает данные осмотра по Id заявки, десериализует в объект Inspection
        public Inspection GetInspection(int id)
        {
            string json = inspectionAdapter.FetchInspection(id);
            return JsonConvert.DeserializeObject<Inspection>(json);
        }

        // Сохраняет данные осмотра (автоматически устанавливает текущую дату)
        // Параметр id не используется - возможно, лишний или нужен для проверки
        public void SaveInspection(int id, Inspection inspection)
        {
            string json = JsonConvert.SerializeObject(inspection);
            inspectionAdapter.PostInspection(json);
        }

        // ========== EstimateAdapter методы ==========

        // Получает смету по Id заявки, десериализует в объект Estimate
        public Estimate GetEstimate(int requestId)
        {
            string json = estimateAdapter.FetchEstimate(requestId);
            return JsonConvert.DeserializeObject<Estimate>(json);
        }

        // Сохраняет смету (если с таким RequestId уже есть - заменяет)
        public void SaveEstimate(int id, Estimate estimate)
        {
            string json = JsonConvert.SerializeObject(estimate);
            estimateAdapter.PostEstimate(json);
        }

        // Подтверждает смету и автоматически обновляет статус заявки на "Смета подтверждена"
        public void ConfirmEstimate(int requestId)
        {
            estimateAdapter.ConfirmEstimate(requestId);
            ChangeStatus(requestId, "Смета подтверждена");
        }

        // Отклоняет смету (удаляет её) и автоматически обновляет статус заявки на "Смета отклонена"
        public void RejectEstimate(int requestId)
        {
            estimateAdapter.RejectEstimate(requestId);
            ChangeStatus(requestId, "Смета отклонена");
        }

        // ========== MasterAdapter методы ==========

        // Получает список всех мастеров, десериализует в список Master
        // При null возвращает пустой список
        public List<Master> GetMasters()
        {
            string json = masterAdapter.FetchMasters();
            return JsonConvert.DeserializeObject<List<Master>>(json) ?? new List<Master>();
        }

        // Назначает мастера на заявку (создаёт анонимный объект с данными)
        // Автоматически меняет статус заявки на "Назначен мастер"
        public void AssignMaster(int requestId, int masterId)
        {
            var assignData = new { requestId = requestId, masterId = masterId };
            string json = JsonConvert.SerializeObject(assignData);
            masterAdapter.PostAssignMaster(json);
        }

        // Сохраняет нового мастера в систему
        public void SaveMaster(Master master)
        {
            string json = JsonConvert.SerializeObject(master);
            masterAdapter.PostMaster(json);
        }
    }
}