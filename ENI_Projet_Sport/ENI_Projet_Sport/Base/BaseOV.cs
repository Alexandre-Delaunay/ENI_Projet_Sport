using ENI_Projet_Sport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Base
{
    public class BaseOV
    {
        public int id { get; set; }
        public DateTime DateMAJ { get; set; }
        public ServiceLocator ServiceLocator { get; set; }
        public BaseOV()
        {
            Initialize();
        }

        public void Initialize()
        {
            ServiceLocator = ServiceLocator.Instance;
        }
    }
}
