using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimePredictionApp.Models
{
    public class CrimePrediction
    {
        [ColumnName("Score")]
        public float Frequency { get; set; }
    }
}
