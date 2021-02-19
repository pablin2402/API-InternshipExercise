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
        public void Delete(string id)
        {
            _priceLogic.DeleteWorkshop(id);
        }

        [HttpPost]
        [Route("workshops-truextend")]
        public void Post([FromBody] WorkshopsDTO newWorkshopDTO)
        {
            _priceLogic.CreateWorkshop(newWorkshopDTO);
        }

        [HttpPut]
        [Route("workshops-truextend/{id}")]
        public void Put(string id, [FromBody] WorkshopsDTO updateWorkShop)
        {
            _priceLogic.UpdateListWorkshop(updateWorkShop, id);
        }
    }
}
