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
        public int Id { get; set; }
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
