using System.Collections.Generic;
using workshops_api.Controllers.DTOModels;

namespace workshops_api.BusinessLogic
{
    public interface IWorkshopLogic
    {
        List<WorkshopsDTO> GetWorkshops();

        void DeleteWorkshop(string code);
        void UpdateListWorkshop(WorkshopsDTO workshopToUpdate, string id);

        void CreateWorkshop(WorkshopsDTO newWorkshop);
        void CancelWorkshop(WorkshopsDTO workshopToUpdate, string id);
        void PostponeWorkshop(WorkshopsDTO workshopToUpdate, string id);
    }
}
