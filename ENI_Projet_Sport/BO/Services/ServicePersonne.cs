using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO.Base;
using BO.Models;

namespace BO.Services
{
    public class ServicePersonne : IServicePersonne
    {
        private BaseDao<Personne> _dao = new BaseDao<Personne>();
        public bool Add(Personne personne)
        {
            return _dao.Insert(personne);
        }

        public bool Delete(Personne personne)
        {
            return _dao.Delete(personne);
        }

        public List<Personne> GetAll()
        {
            return _dao.GetAll();
        }

        public Personne GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(Personne personne)
        {
            return _dao.Update(personne);
        }
        public bool Commit()
        {
            return _dao.Commit();            
        }
    }
}