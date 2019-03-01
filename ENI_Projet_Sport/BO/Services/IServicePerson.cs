using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServicePerson : IServiceBase
    {
        bool Add(Person personne);
        bool Delete(Person personne);
        bool Update(Person personne);
        List<Person> GetAll();
        Person GetById(int id);
    }
}
