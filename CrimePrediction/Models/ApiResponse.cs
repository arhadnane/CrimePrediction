using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimePredictionApp.Models
{
    public class ApiResponse
    {
        public int IncidentsCount { get; set; }
        public int PagesCount { get; set; }
        public List<CrimeIncident> Incidents { get; set; }
    }
}
