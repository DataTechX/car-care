using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_care.Models
{
    public interface IPRepository
    {
        //Funtion Add Edit Del
        void Add(PModel pModel);
        void Edit(PModel pModel);
        void Delete(int id);

        //Searchs
        IEnumerable<PModel> GetAll();
        IEnumerable<PModel> GetByValue(string searchValue);

    }
}
