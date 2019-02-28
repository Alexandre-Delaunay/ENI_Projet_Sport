using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServicePersonne : IServiceBase
    {
        bool Add(Personne personne);
        bool Delete(Personne personne);
        bool Update(Personne personne);
        List<Personne> GetAll();
        Personne GetById(int id);
    }
}
