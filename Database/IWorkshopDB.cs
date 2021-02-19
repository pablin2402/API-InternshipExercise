using System.Collections.Generic;

namespace workshops_api.Database
{
    public interface IWorkshopDB
    {
        List<Workshop> GetAllWorkshops();


        void AddNew(Workshop newWorkshop);

        void Update(Workshop studentToUpdate, string code);

        void Delete(string code);
    }
}
