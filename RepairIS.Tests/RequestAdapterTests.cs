using Xunit;
using Newtonsoft.Json;
using RepairIS.Adapters;
using RepairIS.Models;
using System.IO;
using System.Reflection;

namespace RepairIS.Tests
{
    public class RequestAdapterTests
    {
        [Fact]
        public void UpdateStatus_ShouldChangeStatus()
        {
            // Arrange
            string testFile = "orders.json";
            if (File.Exists(testFile)) File.Delete(testFile);

            var request = new Request { Id = 1, Status = "Ожидает обработки" };
            File.WriteAllText(testFile, JsonConvert.SerializeObject(new[] { request }));

            var adapter = new RequestAdapter();

            // Act
            adapter.UpdateStatus(1, "Принята в работу");

            // Assert
            var saved = JsonConvert.DeserializeObject<Request[]>(File.ReadAllText(testFile));
            Assert.Equal("Принята в работу", saved[0].Status);

            // Cleanup
            File.Delete(testFile);
        }
    }
}