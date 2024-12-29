using Xunit;
using FluentAssertions;
using CrimePredictionApp.Models;
using CrimePredictionApp.ML;
using System.Collections.Generic;

namespace CrimePredictionApp.Tests
{
    public class CrimePredictionModelTests
    {
        [Fact]
        public void Predict_ShouldReturnPrediction()
        {
            // Arrange
            var crimeData = new List<CrimeData>
            {
                new CrimeData { CrimeType = "Theft", Location = "123 Main St", Frequency = 10 },
                new CrimeData { CrimeType = "Assault", Location = "456 Elm St", Frequency = 5 },
                new CrimeData { CrimeType = "Burglary", Location = "789 Oak St", Frequency = 2 }
            };

            var model = new CrimePredictionModel();

            // Act
            var prediction = model.Predict(crimeData);

            // Assert
            prediction.Should().NotBeNull();
            prediction.Frequency.Should().BeGreaterThan(0, because: "the model should return a positive frequency prediction");
        }
    }
}

