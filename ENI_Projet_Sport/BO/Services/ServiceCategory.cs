using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO.Base;
using BO.Models;

namespace BO.Services
{
    public class ServiceCategoryPOI : IServiceCategoryPOI
    {
        private BaseDao<CategoryPOI> _dao = new BaseDao<CategoryPOI>();
        public bool Add(CategoryPOI CategoryPOI)
        {
            return _dao.Insert(CategoryPOI);
        }

        public bool Delete(CategoryPOI CategoryPOI)
        {
            return _dao.Delete(CategoryPOI);
        }

        public List<CategoryPOI> GetAll()
        {
            return _dao.GetAll();
        }

        public CategoryPOI GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(CategoryPOI CategoryPOI)
        {
            return _dao.Update(CategoryPOI);
        }
        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}