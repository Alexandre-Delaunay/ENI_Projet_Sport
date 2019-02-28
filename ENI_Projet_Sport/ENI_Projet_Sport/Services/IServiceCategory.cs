using ENI_Projet_Sport.Base;
using ENI_Projet_Sport.OV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Services
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
