using Xunit;
using RepairIS.Facades;
using RepairIS.Models;
using System.IO;
using System.Linq;

namespace RepairIS.Tests
{
    public class RequestSystemFacadeTests
    {
        private const string TEST_PATH = "test_data/";

        [Fact]
        public void CreateOrder_ShouldCreateNewRequest()
        {
            // Arrange
            if (Directory.Exists(TEST_PATH)) Directory.Delete(TEST_PATH, true);
            Directory.CreateDirectory(TEST_PATH);

            var facade = new RequestSystemFacade();
            var request = new Request { MachineId = 1, ClientId = 1, Description = "Тест", ContactPhone = "123" };

            // Act
            int id = facade.CreateOrder(request);

            // Assert
            Assert.True(id > 0);
            var saved = facade.GetRequest(id);
            Assert.NotNull(saved);
            Assert.Equal("Тест", saved.Description);

            // Cleanup
            Directory.Delete(TEST_PATH, true);
        }

        [Fact]
        public void AddMaster_ShouldAddNewMaster()
        {
            // Arrange
            if (Directory.Exists(TEST_PATH)) Directory.Delete(TEST_PATH, true);
            Directory.CreateDirectory(TEST_PATH);

            var facade = new RequestSystemFacade();
            var master = new Master { Name = "Новый мастер", Phone = "123" };

            // Act
            int id = facade.SaveMaster(master);

            // Assert
            Assert.True(id > 0);
            var masters = facade.GetMasters();
            Assert.Contains(masters, m => m.Name == "Новый мастер");

            // Cleanup
            Directory.Delete(TEST_PATH, true);
        }

        [Fact]
        public void ChangeStatus_ShouldUpdateRequestStatus()
        {
            // Arrange
            if (Directory.Exists(TEST_PATH)) Directory.Delete(TEST_PATH, true);
            Directory.CreateDirectory(TEST_PATH);

            var facade = new RequestSystemFacade();
            var request = new Request { MachineId = 1, ClientId = 1, Description = "Тест", ContactPhone = "123" };
            int id = facade.CreateOrder(request);

            // Act
            bool result = facade.ChangeStatus(id, "Принята в работу");
            var updated = facade.GetRequest(id);

            // Assert
            Assert.True(result);
            Assert.Equal("Принята в работу", updated.Status);

            // Cleanup
            Directory.Delete(TEST_PATH, true);
        }
    }
}