using BO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public class BaseOV
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        public ServiceLocator ServiceLocator { get; set; }
        public BaseOV()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            ServiceLocator = ServiceLocator.Instance;
        }
    }
}
