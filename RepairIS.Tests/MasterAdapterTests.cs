using Xunit;
using Newtonsoft.Json;
using RepairIS.Adapters;
using RepairIS.Models;
using System.IO;

namespace RepairIS.Tests
{
    public class MasterAdapterTests
    {
        [Fact]
        public void PostMaster_ShouldAddMaster()
        {
            // Arrange
            string testFile = "masters.json";
            if (File.Exists(testFile)) File.Delete(testFile);

            var adapter = new MasterAdapter();
            var master = new Master { Name = "Иванов Иван" };

            // Act
            adapter.PostMaster(JsonConvert.SerializeObject(master));

            // Assert
            var saved = JsonConvert.DeserializeObject<Master[]>(File.ReadAllText(testFile));
            Assert.Single(saved);
            Assert.Equal("Иванов Иван", saved[0].Name);

            // Cleanup
            File.Delete(testFile);
        }
    }
}