using System.Collections.Generic;


namespace workshops_api.Database
{
    public interface IWorkshopDB
    {
          public List<Workshop> GetAll();
            public List<Workshop> GetById(string id);
    
    }
}