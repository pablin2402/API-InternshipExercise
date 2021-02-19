using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workshops_api.Database
{
    public class WorkshopDB : IWorkshopDB
    {
        private List<Workshop> workshop { get; set; }

        public WorkshopDB()
        {
            workshop =
                new List<Workshop>()
                {
                    new Workshop()
                    {
                        Id = "WS-1",
                        Name = "INTRODUCTION INTERNAL APPS",
                        Status = "SCHEDULED"
                    },
                    new Workshop()
                    { Id = "WS-2", Name = "OOP", Status = "SCHEDULED" },
                    new Workshop()
                    {
                        Id = "WS-3",
                        Name = "Branching Model and Versioning",
                        Status = "POSTPONED"
                    }
                };
        }

        public List<Workshop> GetAllWorkshops()
        {
            return workshop;
        }
        public void AddNew(Workshop newWorkshop)
        {
            workshop.Add(newWorkshop);
        }

        public void Update(Workshop studentToUpdate, string code)
        {
            foreach (Workshop workshop in GetAllWorkshops())
            {
                if (workshop.Id.Equals(code))
                {
                    workshop.Name = studentToUpdate.Name;
                    workshop.Status = studentToUpdate.Status;

                    break;
                }
            }
        }

        public void Delete(string code)
        {
            int count = 0;

            foreach (Workshop workshop in GetAllWorkshops())
            {
                if (workshop.Equals(code))
                {
                    GetAllWorkshops().RemoveAt(count);
                    break;
                }
                else
                {
                    count += 1;
                }
            }
        }
    }
}
