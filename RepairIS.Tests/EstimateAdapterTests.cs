using Xunit;
using Newtonsoft.Json;
using RepairIS.Adapters;
using RepairIS.Models;
using System.IO;

namespace RepairIS.Tests
{
    public class EstimateAdapterTests
    {
        [Fact]
        public void PostEstimate_ShouldSaveEstimate()
        {
            // Arrange
            string testFile = "estimates.json";
            if (File.Exists(testFile)) File.Delete(testFile);

            var adapter = new EstimateAdapter();
            var estimate = new Estimate { RequestId = 1, WorkCost = 1000 };

            // Act
            adapter.PostEstimate(JsonConvert.SerializeObject(estimate));

            // Assert
            Assert.True(File.Exists(testFile));

            // Cleanup
            File.Delete(testFile);
        }
    }
}