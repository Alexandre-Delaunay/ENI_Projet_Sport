using BO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public class BaseViewModel
    {
        public ServiceLocator ServiceLocator { get; set; }

        public BaseViewModel()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            ServiceLocator = ServiceLocator.Instance;
        }
    }
}
