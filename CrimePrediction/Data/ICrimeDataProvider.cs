using CrimePredictionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimePredictionApp.Data
{
    public interface ICrimeDataProvider
    {
        Task<List<CrimeIncident>> FetchCrimeIncidentsAsync(double latitude, double longitude, string startDate, string endDate, string distance);
    }

}
