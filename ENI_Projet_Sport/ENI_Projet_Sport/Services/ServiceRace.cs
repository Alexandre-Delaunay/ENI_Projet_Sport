using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENI_Projet_Sport.OV;
using ENI_Projet_Sport.Base;

namespace ENI_Projet_Sport.Services
{
    public class ServiceRace : IServiceRace
    {
        private BaseDao<Race> _dao = new BaseDao<Race>();
        public bool Add(Race race)
        {
            return _dao.Insert(race);
        }

        public bool Delete(Race race)
        {
            return _dao.Delete(race);
        }

        public List<Race> GetAll()
        {
            return _dao.GetAll();
        }

        public Race GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(Race race)
        {
            return _dao.Update(race);
        }
        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}