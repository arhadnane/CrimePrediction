using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CrimePredictionApp.Models;

namespace CrimePredictionApp.Data
{
    public class CrimeDataProvider : ICrimeDataProvider
    {
        private static readonly string ApiKey = "YOUR_CRIMEOMETER_API_KEY";
        private static readonly string ApiUrl = "https://api.crimeometer.com/v2/crime-incidents";

        public async Task<List<CrimeIncident>> FetchCrimeIncidentsAsync(double latitude, double longitude, string startDate, string endDate, string distance)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
            var url = $"{ApiUrl}?lat={latitude}&lon={longitude}&datetime_ini={startDate}&datetime_end={endDate}&distance={distance}";

            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseContent);
            return apiResponse?.Incidents ?? new List<CrimeIncident>();
        }
    }
}
