using Microsoft.AspNetCore.Mvc;
using CrimePredictionApp.Services;
using System.Runtime.InteropServices;

namespace CrimePredictionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimePredictionController : ControllerBase
    {
        private readonly CrimePredictionService _crimePredictionService;

        public CrimePredictionController(CrimePredictionService crimePredictionService)
        {
            _crimePredictionService = crimePredictionService;
        }

        [HttpGet("predict")]
        public ActionResult<float> GetCrimePrediction(string crimeType, string location)
        {
            var prediction = _crimePredictionService.PredictCrimeFrequency(crimeType, location);
            return Ok(prediction);
        }
    }
}
