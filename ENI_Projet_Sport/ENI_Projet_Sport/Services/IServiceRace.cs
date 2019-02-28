using ENI_Projet_Sport.Base;
using ENI_Projet_Sport.OV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Services
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
