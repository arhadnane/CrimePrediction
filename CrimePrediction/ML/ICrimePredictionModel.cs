using CrimePredictionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimePredictionApp.ML
{
    public interface ICrimePredictionModel
    {
        public CrimePrediction Predict(List<CrimeData> crimeData);
    }
}
