using Xunit;
using Moq;
using CrimePredictionApp.Data;
using CrimePredictionApp.Models;
using CrimePredictionApp.ML;
using CrimePredictionApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

namespace CrimePredictionApp.Tests
{
    public class CrimePredictionServiceTests
    {
        [Fact]
        public void PredictCrimeFrequency_ShouldReturnPrediction()
        {
            // Arrange
            var mockCrimeDataProvider = new Mock<ICrimeDataProvider>();
            var mockCrimePredictionModel = new Mock<ICrimePredictionModel>();

            var crimeIncidents = new List<CrimeIncident>
            {
                new CrimeIncident { IncidentOffense = "Theft", IncidentAddress = "123 Main St" }
            };

            var crimeData = new List<CrimeData>
            {
                new CrimeData { CrimeType = "Theft", Location = "123 Main St", Frequency = 0 }
            };

            var prediction = new CrimePrediction { Frequency = 5.0f };

            mockCrimeDataProvider.Setup(x => x.FetchCrimeIncidentsAsync(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(crimeIncidents));

            mockCrimePredictionModel.Setup(x => x.Predict(It.IsAny<List<CrimeData>>()))
                .Returns(prediction);

            var service = new CrimePredictionService(mockCrimeDataProvider.Object, mockCrimePredictionModel.Object);

            // Act
            var result = service.PredictCrimeFrequency("Theft", "123 Main St");

            // Assert
            result.Should().Be(5.0f, because: "the prediction model should return the expected frequency");
        }
    }
}
