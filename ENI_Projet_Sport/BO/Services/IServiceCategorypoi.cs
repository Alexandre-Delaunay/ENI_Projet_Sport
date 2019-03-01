using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServiceCategoryPOI : IServiceBase
    {
        bool Add(CategoryPOI categoryPOI);
        bool Delete(CategoryPOI categoryPOI);
        bool Update(CategoryPOI categoryPOI);
        List<CategoryPOI> GetAll();
        CategoryPOI GetById(int id);
    }
}
