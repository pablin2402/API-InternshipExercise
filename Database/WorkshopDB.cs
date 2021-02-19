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

        public List<Workshop> GetAll()
        {
            return workshop;
        }

        public List<Workshop> GetById(string id)
        {
            var pricingbook = workshop.FirstOrDefault(d => d.Id.Equals(id));
            List<Workshop> workshops = new List<Workshop>();
            if (pricingbook != null)
            {
                workshops.Add (pricingbook);
            }

            return workshops;
        }

        public void AddNew(Workshop newWorkshop)
        {
            workshop.Add (newWorkshop);
        }

        public void Update(Workshop studentToUpdate, string code)
        {
            foreach (Workshop workshop in GetAll())
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

            foreach (Workshop workshop in GetAll())
            {
                if (workshop.Equals(code))
                {
                    GetAll().RemoveAt(count);
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
