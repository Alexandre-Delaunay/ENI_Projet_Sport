using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Base
{
    public class BaseOV
    {
        public IServiceLocator ServiceLocator { get; set; }
        public int id { get; set; }

        public BaseOV()
        {
            Initialize();
        }

        public void Initialize()
        {
            ServiceLocator = new ServiceLocator();
        }
    }
}
