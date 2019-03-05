using BO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public class ServiceLocator : IServiceLocator
    {
        private static ServiceLocator instance = null;

        private IDictionary<object, object> services;

        private ServiceLocator()
        {
            services = new Dictionary<object, object>();

            services.Add(typeof(IServiceCategoryPOI), new ServiceCategoryPOI());
            services.Add(typeof(IServicePerson), new ServicePerson());
            services.Add(typeof(IServiceRace), new ServiceRace());
            services.Add(typeof(IServiceDisplayConfiguration), new ServiceDisplayConfiguration());
            services.Add(typeof(IServicePOI), new ServicePOI());
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceLocator();
                }
                return instance;
            }
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }

        public bool Commit()
        {
            bool success = false;
            try
            {
                foreach (var service in services)
                {
                    var serviceBase = service.Value as IServiceBase;
                    serviceBase.Commit();
                }

                success = true;
            }
            catch (Exception)
            {
                throw new ApplicationException("An error occured during the commit");
            }

            return success;
        }
    }
}
