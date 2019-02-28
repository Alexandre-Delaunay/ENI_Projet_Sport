using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public interface IBaseDao<T> where T : class
    {
        bool Insert(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T GetByID(int id);
        List<T> GetAll();
    }
}
