using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENI_Projet_Sport.OV;
using ENI_Projet_Sport.Base;

namespace ENI_Projet_Sport.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private BaseDao<Category> _dao = new BaseDao<Category>();
        public bool Add(Category category)
        {
            return _dao.Insert(category);
        }

        public bool Delete(Category category)
        {
            return _dao.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _dao.GetAll();
        }

        public Category GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(Category category)
        {
            return _dao.Update(category);
        }
        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}