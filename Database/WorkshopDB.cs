using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workshops_api.Database
{
    public class WorkshopDB : IWorkshopDB
    {
        public List<Workshop> GetAll()
        {
            return new List<Workshop>()
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
    }
}
