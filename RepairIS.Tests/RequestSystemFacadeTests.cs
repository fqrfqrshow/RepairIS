using Xunit;
using RepairIS.Facades;
using RepairIS.Models;
using System.IO;

namespace RepairIS.Tests
{
    public class RequestSystemFacadeTests
    {
        [Fact]
        public void FullWorkflow_ShouldWork()
        {
            // Очищаем файлы перед тестом
            string[] files = { "orders.json", "masters.json", "machines.json", "inspections.json", "estimates.json" };
            foreach (var f in files)
                if (File.Exists(f)) File.Delete(f);

            var facade = new RequestSystemFacade();

            // 1. Добавляем мастера
            var master = new Master { Name = "Тестовый мастер" };
            facade.SaveMaster(master);

            // 2. Добавляем станок
            var machine = new Machine { Model = "Станок", OwnerId = 1 };
            facade.SaveMachine(Newtonsoft.Json.JsonConvert.SerializeObject(machine));

            // 3. Создаём заявку
            var request = new Request { MachineId = 1, ClientId = 1, Status = "Ожидает обработки" };
            facade.CreateOrder(Newtonsoft.Json.JsonConvert.SerializeObject(request));

            // 4. Проверяем
            var savedRequest = facade.GetRequest(1);

            Assert.NotNull(savedRequest);
            Assert.Equal("Ожидает обработки", savedRequest.Status);

            // Cleanup
            foreach (var f in files)
                if (File.Exists(f)) File.Delete(f);
        }
    }
}