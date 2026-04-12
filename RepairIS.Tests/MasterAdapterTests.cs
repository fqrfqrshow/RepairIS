using Xunit;
using RepairIS.Adapters;
using RepairIS.Models;
using System.IO;
using System.Linq;

namespace RepairIS.Tests
{
    public class MasterAdapterTests
    {
        private const string TEST_MASTERS_FILE = "test_masters.json";
        private const string TEST_ORDERS_FILE = "test_orders.json";

        [Fact]
        public void AddMaster_ShouldSaveMaster()
        {
            // Arrange
            if (File.Exists(TEST_MASTERS_FILE)) File.Delete(TEST_MASTERS_FILE);
            var adapter = new MasterAdapter(TEST_MASTERS_FILE, TEST_ORDERS_FILE);
            var master = new Master { Name = "Иван Петров", Phone = "+79991234567", Email = "ivan@repair.ru" };

            // Act
            int id = adapter.AddMaster(master);

            // Assert
            Assert.True(File.Exists(TEST_MASTERS_FILE));
            Assert.Equal(1, id);

            // Cleanup
            File.Delete(TEST_MASTERS_FILE);
        }

        [Fact]
        public void GetAllMasters_ShouldReturnAllMasters()
        {
            // Arrange
            if (File.Exists(TEST_MASTERS_FILE)) File.Delete(TEST_MASTERS_FILE);
            var adapter = new MasterAdapter(TEST_MASTERS_FILE, TEST_ORDERS_FILE);
            adapter.AddMaster(new Master { Name = "Мастер 1", Phone = "111" });
            adapter.AddMaster(new Master { Name = "Мастер 2", Phone = "222" });

            // Act
            var masters = adapter.GetAllMasters();

            // Assert
            Assert.Equal(2, masters.Count);
            Assert.Equal("Мастер 1", masters[0].Name);
            Assert.Equal("Мастер 2", masters[1].Name);

            // Cleanup
            File.Delete(TEST_MASTERS_FILE);
        }

        [Fact]
        public void GetMasterById_ShouldReturnCorrectMaster()
        {
            // Arrange
            if (File.Exists(TEST_MASTERS_FILE)) File.Delete(TEST_MASTERS_FILE);
            var adapter = new MasterAdapter(TEST_MASTERS_FILE, TEST_ORDERS_FILE);
            adapter.AddMaster(new Master { Name = "Тестовый мастер", Phone = "123" });

            // Act
            var master = adapter.GetMasterById(1);

            // Assert
            Assert.NotNull(master);
            Assert.Equal("Тестовый мастер", master.Name);

            // Cleanup
            File.Delete(TEST_MASTERS_FILE);
        }
    }
}