using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServicePOI: IServiceBase
    {
        bool Add(POI poi);
        bool Delete(POI poi);
        bool Update(POI poi);
        List<POI> GetAll();
        POI GetById(int id);
    }
}
