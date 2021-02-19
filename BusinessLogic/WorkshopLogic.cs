using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Workshop> allWorkShops = _workshopDB.GetAllWorkshops();

            List<WorkshopsDTO> workshopsLists = new List<WorkshopsDTO>();

            foreach (Workshop listWS in allWorkShops)
            {
                fillWorkShopList(workshopsLists, listWS);
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
            List<Workshop> allWorkShops = _workshopDB.GetAllWorkshops();

            List<WorkshopsDTO> workshopsLists = new List<WorkshopsDTO>();

            foreach (Workshop listWS in allWorkShops)
            {
                fillWorkShopList(workshopsLists, listWS);
            }

            return workshopsLists;
        }

        public void DeleteWorkshop(string code)
        {
            int count = 0;

            foreach (WorkshopsDTO workshop in GetWorkshops())
            {
                if (workshop.Id.Equals(code))
                {
                    GetWorkshops().RemoveAt(count);
                }
                else
                {
                    count += 1;
                }
            }
            _workshopDB.Delete(code);
        }

        public void UpdateListWorkshop(WorkshopsDTO workshopToUpdate, string id)
        {
            foreach (WorkshopsDTO workshop in GetWorkshops())
            {
                if (workshop.Id.Equals(id))
                {
                    workshop.Name = workshopToUpdate.Name;
                    workshop.Status = workshopToUpdate.Status;

                    break;
                }
            }

            Workshop productDB = new Workshop();

            productDB.Name = workshopToUpdate.Name;
            productDB.Status = workshopToUpdate.Status;

            _workshopDB.Update(productDB, id);
        }

        public void CreateWorkshop(WorkshopsDTO newWorkshop)
        {
            bool flag = false;

            List<Workshop> allProducts = _workshopDB.GetAllWorkshops();

            Workshop productDB = new Workshop();

            foreach (Workshop product in allProducts)
            {
                if (product.Id == newWorkshop.Id)
                {
                    product.Name = newWorkshop.Name;
                    product.Status = newWorkshop.Status;

                    flag = true;
                }
            }

            if (flag)
            {
                UpdateListWorkshop(newWorkshop, productDB.Id);
            }
            else
            {
                WorkshopsDTO productCode =
                    generateCode(allProducts, newWorkshop);

                productDB.Name = productCode.Name;
                productDB.Status = productCode.Status;

                _workshopDB.AddNew(productDB);
            }
        }

        private WorkshopsDTO generateCode(List<Workshop> listToAdd, WorkshopsDTO workshops)
        {
            List<Workshop> workshopList = listToAdd;

            int id = workshopList.Count() + 1;
            string code = "WS-1-" + id;
            foreach (Workshop sl in workshopList)
            {
                if (code == sl.Id)
                {
                    id += 1;
                    code = "WS-1" + id;
                }
            }
            workshops.Id = code;

            return workshops;
        }
    }
}
