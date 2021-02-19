using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using workshops_api.BusinessLogic;
using workshops_api.Controllers.DTOModels;

namespace workshops_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWorkshopLogic _priceLogic;

        public WeatherForecastController(IWorkshopLogic pricelogic)
        {
            _priceLogic = pricelogic;
        }

        [HttpGet]
        // [Route("pricing-books")]
        public IEnumerable<WorkshopsDTO> GetAll()
        {
            return _priceLogic.GetWorkshops();
        }
        /*
        private static readonly string[]
            Summaries =
                new []
                {
                    "Freezing",
                    "Bracing",
                    "Chilly",
                    "Cool",
                    "Mild",
                    "Warm",
                    "Balmy",
                    "Hot",
                    "Sweltering",
                    "Scorching"
                };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger
        )
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable
                .Range(1, 5)
                .Select(index =>
                    new WeatherForecast {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    })
                .ToArray();
        }
        */
    }
}
