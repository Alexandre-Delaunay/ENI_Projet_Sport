using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Models;
using BO.Base;

namespace BO.Services
{
    public class ServiceRaceType : IServiceRaceType
    {
        private BaseDao<RaceType> _dao = new BaseDao<RaceType>();
        public bool Add(RaceType typeCourse)
        {
            return _dao.Insert(typeCourse);
        }

        public bool Delete(RaceType typeCourse)
        {
            return _dao.Delete(typeCourse);
        }

        public List<RaceType> GetAll()
        {
            return _dao.GetAll();
        }

        public RaceType GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(RaceType typeCourse)
        {
            return _dao.Update(typeCourse);
        }
        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}
