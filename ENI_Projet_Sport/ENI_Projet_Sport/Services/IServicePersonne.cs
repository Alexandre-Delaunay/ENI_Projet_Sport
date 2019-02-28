using ENI_Projet_Sport.Base;
using ENI_Projet_Sport.OV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Services
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
