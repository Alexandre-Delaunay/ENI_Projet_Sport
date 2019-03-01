using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Models;
using BO.Base;

namespace BO.Services
{
    public class ServiceDisplayConfiguration : IServiceDisplayConfiguration
    {
        private BaseDao<DisplayConfiguration> _dao = new BaseDao<DisplayConfiguration>();
        public bool Add(DisplayConfiguration displayConfiguration)
        {
            return _dao.Insert(displayConfiguration);
        }

        public bool Delete(DisplayConfiguration displayConfiguration)
        {
            return _dao.Delete(displayConfiguration);
        }

        public List<DisplayConfiguration> GetAll()
        {
            return _dao.GetAll();
        }

        public DisplayConfiguration GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(DisplayConfiguration displayConfiguration)
        {
            return _dao.Update(displayConfiguration);
        }

        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}
