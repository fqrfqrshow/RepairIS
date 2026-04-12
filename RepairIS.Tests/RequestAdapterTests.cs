using Xunit;
using RepairIS.Adapters;
using RepairIS.Models;
using System;
using System.IO;
using System.Linq;

namespace RepairIS.Tests
{
    public class RequestAdapterTests
    {
        private const string TEST_REQUESTS_FILE = "test_orders.json";
        private const string TEST_HISTORY_FILE = "test_history.json";

        [Fact]
        public void UpdateStatus_ShouldChangeStatus()
        {
            // Arrange
            if (File.Exists(TEST_REQUESTS_FILE)) File.Delete(TEST_REQUESTS_FILE);
            if (File.Exists(TEST_HISTORY_FILE)) File.Delete(TEST_HISTORY_FILE);

            var adapter = new RequestAdapter(TEST_REQUESTS_FILE, TEST_HISTORY_FILE);

            // Создаем заявку через OrderAdapter
            var orderAdapter = new OrderAdapter(TEST_REQUESTS_FILE, TEST_REQUESTS_FILE);
            var request = new Request
            {
                Id = 1,
                ClientId = 1,
                MachineId = 1,
                Status = "Ожидает обработки",
                Description = "Тест",
                ContactPhone = "79991234567"  // ← ДОБАВЛЕНО
            };
            orderAdapter.CreateRequest(request);

            // Act
            bool result = adapter.UpdateStatus(1, "Принята в работу");
            var updated = adapter.GetRequestById(1);

            // Assert
            Assert.True(result);
            Assert.Equal("Принята в работу", updated.Status);

            // Cleanup
            File.Delete(TEST_REQUESTS_FILE);
            File.Delete(TEST_HISTORY_FILE);
        }

        [Fact]
        public void GetRequestsByClientId_ShouldReturnCorrectRequests()
        {
            // Arrange
            if (File.Exists(TEST_REQUESTS_FILE)) File.Delete(TEST_REQUESTS_FILE);

            var orderAdapter = new OrderAdapter(TEST_REQUESTS_FILE, TEST_REQUESTS_FILE);
            var adapter = new RequestAdapter(TEST_REQUESTS_FILE, TEST_HISTORY_FILE);

            // ДОБАВЛЕН ContactPhone во все заявки
            orderAdapter.CreateRequest(new Request
            {
                ClientId = 1,
                MachineId = 1,
                Description = "Заявка 1",
                ContactPhone = "79991234567"
            });
            orderAdapter.CreateRequest(new Request
            {
                ClientId = 1,
                MachineId = 2,
                Description = "Заявка 2",
                ContactPhone = "79991234567"
            });
            orderAdapter.CreateRequest(new Request
            {
                ClientId = 2,
                MachineId = 3,
                Description = "Заявка 3",
                ContactPhone = "79991234567"
            });

            // Act
            var clientRequests = adapter.GetRequestsByClientId(1);

            // Assert
            Assert.Equal(2, clientRequests.Count);
            Assert.All(clientRequests, r => Assert.Equal(1, r.ClientId));

            // Cleanup
            File.Delete(TEST_REQUESTS_FILE);
        }
    }
}