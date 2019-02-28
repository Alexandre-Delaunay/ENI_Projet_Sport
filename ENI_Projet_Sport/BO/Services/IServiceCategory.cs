using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServiceCategory: IServiceBase
    {
        bool Add(Category category);
        bool Delete(Category category);
        bool Update(Category category);
        List<Category> GetAll();
        Category GetById(int id);        
    }
}
