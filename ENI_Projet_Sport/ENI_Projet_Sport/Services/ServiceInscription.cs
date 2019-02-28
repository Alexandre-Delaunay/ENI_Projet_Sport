using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENI_Projet_Sport.OV;
using ENI_Projet_Sport.Base;

namespace ENI_Projet_Sport.Services
{
    public class ServiceInscription : IServiceInscription
    {
        private BaseDao<Inscription> _dao = new BaseDao<Inscription>();
        public bool Add(Inscription inscription)
        {
            return _dao.Insert(inscription);
        }

        public bool Delete(Inscription inscription)
        {
            return _dao.Delete(inscription);
        }

        public List<Inscription> GetAll()
        {
            return _dao.GetAll();
        }

        public Inscription GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(Inscription inscription)
        {
            return _dao.Update(inscription);
        }
        public bool Commit()
        {
            return _dao.Commit();
        }
    }
}