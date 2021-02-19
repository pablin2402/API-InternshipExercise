using System;
using System.Collections.Generic;
using workshops_api.Controllers.DTOModels;
using workshops_api.Database;

namespace workshops_api.BusinessLogic
{
    public class WorkshopLogic : IWorkshopLogic
    {
        private readonly IWorkshopDB _workshopDB;

        public WorkshopLogic(IWorkshopDB workshopDB)
        {
            _workshopDB = workshopDB;
        }

        public List<WorkshopsDTO> GetWorkshops()
        {
            List<Workshop> allWorkShops = _workshopDB.GetAll();

            List<WorkshopsDTO> workshopsLists = new List<WorkshopsDTO>();

            foreach (Workshop listWS in allWorkShops)
            {
                fillWorkShopList (workshopsLists, listWS);
            }

            return workshopsLists;
        }

        public void fillWorkShopList(
            List<WorkshopsDTO> workshopsLists,
            Workshop listWS
        )
        {
            workshopsLists
                .Add(new WorkshopsDTO()
                { Id = listWS.Id, Name = listWS.Name, Status = listWS.Status });
        }

        public List<WorkshopsDTO> GetWorkshopsById(string id)
        {
            List<Workshop> allWorkShops = _workshopDB.GetAll();

            List<WorkshopsDTO> workshopsLists = new List<WorkshopsDTO>();

            foreach (Workshop listWS in allWorkShops)
            {
                fillWorkShopList (workshopsLists, listWS);
            }

            return workshopsLists;
        }

        public bool DeleteWorkShops(string id)
        {
            List<WorkshopsDTO> workshopsList = GetWorkshops();
            foreach (WorkshopsDTO pbDTO in workshopsList)
            {
                if (pbDTO.Id.Equals(id))
                {
                    workshopsList.Remove (pbDTO);
                    return true;
                }
            }
            return false;
        }
        /*
        public WorkshopsDTO
        UpdateListProduct(WorkshopsDTO workshopToUpdate, string id)
        {
            Workshop pbUpdated = new Workshop();

            pbUpdated.Name = workshopToUpdate.Name;
            pbUpdated.Status = workshopToUpdate.Status;
            
            return new WorkshopsDTO()
            { Id = pbInDB.Id, Name = pbInDB.Name, Status = pbInDB.Status };
        
        }
    */
    }
}
