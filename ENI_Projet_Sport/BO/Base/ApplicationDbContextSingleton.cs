using ENI_Projet_Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public class ApplicationDbContextSingleton
    {
        private static ApplicationDbContext _contextInstance = null;
        public static ApplicationDbContext ContextInstance
        {
            get
            {
                if (_contextInstance == null)
                {
                    _contextInstance = new ApplicationDbContext();
                }
                return _contextInstance;
            }
        }
    }
}
