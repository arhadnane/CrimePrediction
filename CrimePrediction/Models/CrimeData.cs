using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimePredictionApp.Models
{
    public class CrimeData
    {
        public string CrimeType { get; set; }
        public string Location { get; set; }
        public float Frequency { get; set; }
    }
}
