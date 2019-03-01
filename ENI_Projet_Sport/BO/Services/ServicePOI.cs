using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Models;
using BO.Base;

namespace BO.Services
{
    public class ServicePOI : IServicePOI
    {
        private BaseDao<POI> _dao = new BaseDao<POI>();
        public bool Add(POI poi)
        {
            return _dao.Insert(poi);
        }

        public bool Delete(POI poi)
        {
            return _dao.Delete(poi);
        }

        public List<POI> GetAll()
        {
            return _dao.GetAll();
        }

        public POI GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(POI poi)
        {
            return _dao.Update(poi);
        }
        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}
