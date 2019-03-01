using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO.Base;
using BO.Models;

namespace BO.Services
{
    public class ServicePerson : IServicePerson
    {
        private BaseDao<Person> _dao = new BaseDao<Person>();
        public bool Add(Person personne)
        {
            return _dao.Insert(personne);
        }

        public bool Delete(Person personne)
        {
            return _dao.Delete(personne);
        }

        public List<Person> GetAll()
        {
            return _dao.GetAll();
        }

        public Person GetById(int id)
        {
            return _dao.GetByID(id);
        }

        public bool Update(Person personne)
        {
            return _dao.Update(personne);
        }
        public bool Commit()
        {
            return _dao.Commit();            
        }
    }
}