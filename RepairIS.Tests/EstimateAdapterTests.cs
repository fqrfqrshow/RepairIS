using Xunit;
using Newtonsoft.Json;
using RepairIS.Adapters;
using RepairIS.Models;
using System.IO;
using System.Linq;

namespace RepairIS.Tests
{
    public class EstimateAdapterTests
    {
        private const string TEST_FILE = "test_estimates.json";

        [Fact]
        public void SaveEstimate_ShouldSaveEstimate()
        {
            // Arrange
            if (File.Exists(TEST_FILE)) File.Delete(TEST_FILE);
            var adapter = new EstimateAdapter(TEST_FILE);
            var estimate = new Estimate { RequestId = 1, WorkCost = 1000 };

            // Act
            int id = adapter.SaveEstimate(estimate);

            // Assert
            Assert.True(File.Exists(TEST_FILE));
            Assert.Equal(1, id);

            // Cleanup
            File.Delete(TEST_FILE);
        }

        [Fact]
        public void GetEstimateByRequestId_ShouldReturnCorrectEstimate()
        {
            // Arrange
            if (File.Exists(TEST_FILE)) File.Delete(TEST_FILE);
            var adapter = new EstimateAdapter(TEST_FILE);
            var estimate = new Estimate { RequestId = 1, WorkCost = 1000, PartsCost = 500 };
            adapter.SaveEstimate(estimate);

            // Act
            var result = adapter.GetEstimateByRequestId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1000, result.WorkCost);
            Assert.Equal(500, result.PartsCost);

            // Cleanup
            File.Delete(TEST_FILE);
        }

        [Fact]
        public void ConfirmEstimate_ShouldSetIsConfirmedToTrue()
        {
            // Arrange
            if (File.Exists(TEST_FILE)) File.Delete(TEST_FILE);
            var adapter = new EstimateAdapter(TEST_FILE);
            var estimate = new Estimate { RequestId = 1, WorkCost = 1000 };
            adapter.SaveEstimate(estimate);

            // Act
            bool result = adapter.ConfirmEstimate(1);
            var confirmed = adapter.GetEstimateByRequestId(1);

            // Assert
            Assert.True(result);
            Assert.True(confirmed.IsConfirmed);

            // Cleanup
            File.Delete(TEST_FILE);
        }

        [Fact]
        public void RejectEstimate_ShouldDeleteEstimate()
        {
            // Arrange
            if (File.Exists(TEST_FILE)) File.Delete(TEST_FILE);
            var adapter = new EstimateAdapter(TEST_FILE);
            var estimate = new Estimate { RequestId = 1, WorkCost = 1000 };
            adapter.SaveEstimate(estimate);

            // Act
            bool result = adapter.RejectEstimate(1);
            var deleted = adapter.GetEstimateByRequestId(1);

            // Assert
            Assert.True(result);
            Assert.Null(deleted);

            // Cleanup
            File.Delete(TEST_FILE);
        }
    }
}