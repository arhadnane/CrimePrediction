using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrimePredictionApp.Data;
using CrimePredictionApp.Services;
using CrimePredictionApp.ML;
using CrimePredictionApp.Controllers;


namespace CrimePredictionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var crimePredictionService = host.Services.GetRequiredService<CrimePredictionController>();

            try
            {
                // Call your prediction method or start your app
                var prediction = crimePredictionService.GetCrimePrediction("Motor Vehicle Theft", "050XX N LAKE SHORE DR SB");
                Console.WriteLine($"Predicted crime frequency: {prediction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while predicting crime frequency: {ex.Message}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Register services and dependencies
                    services.AddSingleton<CrimeDataProvider>();
                    services.AddSingleton<CrimePredictionModel>();
                    services.AddSingleton<CrimePredictionService>();
                    services.AddSingleton<CrimePredictionController>();
                });
    }
}
