using BusinessLogic.Exception;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public void fillWorkShopList(List<WorkshopsDTO> workshopsLists, Workshop listWS)
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
            if (string.IsNullOrEmpty(code))
            {
                throw new EmptyOrNullStatus("Code cannot be null");
            }

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
            if (string.IsNullOrEmpty(id))
            {
                throw new EmptyOrNullStatus("Code cannot be null");
            }

            foreach (var workshop in GetWorkshops().Where(workshop => workshop.Id.Equals(id)))
            {
                workshop.Name = workshopToUpdate.Name;
                workshop.Status = workshopToUpdate.Status;
            }

            Workshop workshopDB = new Workshop();

            workshopDB.Name = workshopToUpdate.Name;
            workshopDB.Status = workshopToUpdate.Status;

            _workshopDB.Update(workshopDB, id);
        }
        public void CancelWorkshop(WorkshopsDTO workshopToUpdate, string id)
        {
            if (string.IsNullOrEmpty(workshopToUpdate.Id))
            {
                throw new EmptyOrNullId("Code cannot be null");
            }

            foreach (var workshop in GetWorkshops().Where(workshop => workshop.Id.Equals(id)))
            {
                workshop.Name = workshopToUpdate.Name;
                workshop.Status = Convert.ToString(Status.CANCELLED);
            }

            Workshop WorkshopDB = new Workshop();
            WorkshopDB.Name = workshopToUpdate.Name;

            WorkshopDB.Status = Convert.ToString(Status.CANCELLED);

            _workshopDB.Update(WorkshopDB, id);
        }
        public void PostponeWorkshop(WorkshopsDTO workshopToUpdate, string id)
        {
            if (string.IsNullOrEmpty(workshopToUpdate.Id))
            {
                throw new EmptyOrNullId("Code cannot be null");
            }

            foreach (var workshop in GetWorkshops().Where(workshop => workshop.Id.Equals(id)))
            {
                workshop.Name = workshopToUpdate.Name;
                workshop.Status = Convert.ToString(Status.POSTPONED);
            }

            Workshop WorkshopDB = new Workshop();

            WorkshopDB.Name = workshopToUpdate.Name;
            WorkshopDB.Status = Convert.ToString(Status.POSTPONED);

            _workshopDB.Update(WorkshopDB, id);
        }


        public void CreateWorkshop(WorkshopsDTO newWorkshop)
        {

            if (string.IsNullOrEmpty(newWorkshop.Name))
            {
                throw new EmptyOrNullStatus("Name cannot be null");
            }
            if (string.IsNullOrEmpty(newWorkshop.Status))
            {
                throw new EmptyOrNullStatus("Status cannot be null");
            }

            bool flag = false;

            List<Workshop> allProducts = _workshopDB.GetAllWorkshops();

            Workshop workshopDB = new Workshop();
            foreach (var workshop in allProducts.Where(workshop => workshop.Id == newWorkshop.Id))
            {
                workshop.Name = newWorkshop.Name;
                workshop.Status = newWorkshop.Status;
                flag = true;
            }

            if (flag)
            {
                UpdateListWorkshop(newWorkshop, workshopDB.Id);
            }
            else
            {
                WorkshopsDTO workshopCode =
                    generateCode(allProducts, newWorkshop);

                workshopDB.Name = workshopCode.Name;
                workshopDB.Status = workshopCode.Status;

                _workshopDB.AddNew(workshopDB);
            }
        }

        private WorkshopsDTO generateCode(List<Workshop> listToAdd, WorkshopsDTO workshops)
        {
            List<Workshop> workshopList = listToAdd;
            const string IdName = "WS-";
            int id = workshopList.Count() + 1;
            string code = IdName + id;
            foreach (var _ in workshopList.Where(sl => code == sl.Id).Select(sl => new { }))
            {
                id += 1;
                code = IdName + id;
            }

            workshops.Id = code;

            return workshops;
        }
    }
}
