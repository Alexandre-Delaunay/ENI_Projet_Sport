using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServiceRaceType
    {
        bool Add(RaceType raceType);
        bool Delete(RaceType raceType);
        bool Update(RaceType raceType);
        List<RaceType> GetAll();
        RaceType GetById(int id);
    }
}
