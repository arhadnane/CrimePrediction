using CrimePredictionApp.Data;
using CrimePredictionApp.Models;
using CrimePredictionApp.ML;
using System.Linq;

namespace CrimePredictionApp.Services
{
    public class CrimePredictionService
    {
        private readonly ICrimeDataProvider _crimeDataProvider;
        private readonly ICrimePredictionModel _crimePredictionModel;

        public CrimePredictionService(ICrimeDataProvider crimeDataProvider, ICrimePredictionModel crimePredictionModel)
        {
            _crimeDataProvider = crimeDataProvider;
            _crimePredictionModel = crimePredictionModel;
        }

        public float PredictCrimeFrequency(string crimeType, string location)
        {
            // Fetch data and make prediction
            var crimeIncidents = _crimeDataProvider.FetchCrimeIncidentsAsync(41.9751781, -87.6499609, "2023-01-01T00:00:00Z", "2023-12-31T23:59:59Z", "2mi").Result;
            var crimeData = ConvertToCrimeData(crimeIncidents);
            var prediction = _crimePredictionModel.Predict(crimeData);
            return prediction.Frequency;
        }

        private List<CrimeData> ConvertToCrimeData(List<CrimeIncident> crimeIncidents)
        {
            return crimeIncidents.Select(ci => new CrimeData
            {
                CrimeType = ci.IncidentOffense,
                Location = ci.IncidentAddress,
                Frequency = 0 // Assuming Frequency is not available in CrimeIncident and will be predicted
            }).ToList();
        }
    }
}
