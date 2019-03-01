using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServiceRace : IServiceBase
    {
        bool Add(Race race);
        bool Delete(Race race);
        bool Update(Race race);
        List<Race> GetAll();
        Race GetById(int id);
    }
}
