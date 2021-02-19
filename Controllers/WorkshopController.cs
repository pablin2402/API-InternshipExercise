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
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopLogic _priceLogic;

        public WorkshopController(IWorkshopLogic pricelogic)
        {
            _priceLogic = pricelogic;
        }
        //GET: https://localhost:5001/Workshop/workshops-truextend
        [HttpGet]
        [Route("workshops-truextend")]
        public IEnumerable<WorkshopsDTO> GetAll()
        {
            return _priceLogic.GetWorkshops();
        }
        //DELETE: https://localhost:5001/Workshop/workshops-truextend/WS-1

        [HttpDelete]
        [Route("workshops-truextend/{id}")]
        public void Delete(string id)
        {
            _priceLogic.DeleteWorkshop(id);
        }
        //POST: https://localhost:5001/Workshop/workshops-truextend
        [HttpPost]
        [Route("workshops-truextend")]
        public void Post([FromBody] WorkshopsDTO newWorkshopDTO)
        {
            _priceLogic.CreateWorkshop(newWorkshopDTO);
        }
        //PUT: https://localhost:5001/Workshop/workshops-truextend/WS-1
        [HttpPut]
        [Route("workshops-truextend/{id}")]
        public void Put(string id, [FromBody] WorkshopsDTO updateWorkShop)
        {
            _priceLogic.UpdateListWorkshop(updateWorkShop, id);
        }
        //PUT: https://localhost:5001/Workshop/workshops-truextend/status-cancelled/WS-1
        [HttpPut]
        [Route("workshops-truextend/status-cancelled/{id}")]
        public void CancelledWorkshop(string id, [FromBody] WorkshopsDTO updateWorkShop)
        {
            _priceLogic.CancelWorkshop(updateWorkShop, id);
        }
        //PUT: https://localhost:5001/Workshop/workshops-truextend/status-postponed/WS-1

        [HttpPut]
        [Route("workshops-truextend/status-postponed/{id}")]
        public void PostponedWorkshop(string id, [FromBody] WorkshopsDTO updateWorkShop)
        {
            _priceLogic.PostponeWorkshop(updateWorkShop, id);
        }
    }
}
