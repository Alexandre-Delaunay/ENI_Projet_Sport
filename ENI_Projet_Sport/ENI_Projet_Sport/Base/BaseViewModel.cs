using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Base
{
    public class BaseViewModel
    {
        public ServiceLocator ServiceLocator { get; set; }

        public BaseViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            ServiceLocator = ServiceLocator.Instance;
        }
    }
}
