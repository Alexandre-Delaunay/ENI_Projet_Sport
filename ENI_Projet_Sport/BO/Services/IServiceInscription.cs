using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServiceInscription: IServiceBase
    {
        bool Add(Inscription inscription);
        bool Delete(Inscription inscription);
        bool Update(Inscription inscription);
        List<Inscription> GetAll();
        Inscription GetById(int id);        
    }
}
