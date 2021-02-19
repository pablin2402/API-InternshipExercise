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
        [Route("workshops-truextend")]
        public IEnumerable<WorkshopsDTO> GetAll()
        {
            return _priceLogic.GetWorkshops();
        }

        [HttpDelete]
        [Route("workshops-truextend/{id}")]
        public bool
        Delete(string id) // CI:65008816
        {
            return _priceLogic.DeleteWorkShops(id);
        }
    }
}
