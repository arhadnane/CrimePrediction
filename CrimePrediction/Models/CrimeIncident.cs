using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimePredictionApp.Models
{
    public class CrimeIncident
    {
        public string IncidentOffense { get; set; }
        public string IncidentAddress { get; set; }
        public double IncidentLatitude { get; set; }
        public double IncidentLongitude { get; set; }
    }
}
