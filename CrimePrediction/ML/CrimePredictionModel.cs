using Microsoft.ML;
using CrimePredictionApp.Models;
using Microsoft.ML.Data;

namespace CrimePredictionApp.ML
{
    public class CrimePredictionModel
    {
        private readonly MLContext _mlContext;

        public CrimePredictionModel()
        {
            _mlContext = new MLContext();
        }

        public CrimePrediction Predict(List<CrimeData> crimeData)
        {
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(crimeData);

            // Define pipeline for ML model (OneHotEncoding, SDCA)
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding("CrimeTypeEncoded", "CrimeType")
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding("LocationEncoded", "Location"))
                .Append(_mlContext.Transforms.Concatenate("Features", "CrimeTypeEncoded", "LocationEncoded"))
                .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: "Frequency", featureColumnName: "Features"));

            var model = pipeline.Fit(dataView);
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<CrimeData, CrimePrediction>(model);

            // Return a prediction based on sample data
            var testSample = new CrimeData
            {
                CrimeType = "Motor Vehicle Theft",
                Location = "050XX N LAKE SHORE DR SB"
            };

            return predictionEngine.Predict(testSample);
        }
    }
}
