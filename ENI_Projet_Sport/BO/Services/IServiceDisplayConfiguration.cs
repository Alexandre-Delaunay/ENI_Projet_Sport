using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Services
{
    public interface IServiceDisplayConfiguration
    {
        bool Add(DisplayConfiguration displayConfiguration);
        bool Delete(DisplayConfiguration displayConfiguration);
        bool Update(DisplayConfiguration displayConfiguration);
        List<DisplayConfiguration> GetAll();
        DisplayConfiguration GetById(int id);
    }
}
