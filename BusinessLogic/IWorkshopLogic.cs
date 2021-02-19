using System.Collections.Generic;
using workshops_api.Controllers.DTOModels;

namespace workshops_api.BusinessLogic
{
    public interface IWorkshopLogic
    {
        List<WorkshopsDTO> GetWorkshops();
    }
}
