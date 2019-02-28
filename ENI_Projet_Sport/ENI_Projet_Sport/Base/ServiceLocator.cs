using ENI_Projet_Sport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Base
{
    public class ServiceLocator : IServiceLocator
    {
        private static ServiceLocator instance = null;

        private IDictionary<object, object> services;

        private ServiceLocator()
        {
            services = new Dictionary<object, object>();

            services.Add(typeof(IServiceCategory), new ServiceCategory());
            services.Add(typeof(IServiceInscription), new ServiceInscription());
            services.Add(typeof(IServicePersonne), new ServicePersonne());
            services.Add(typeof(IServiceRace), new ServiceRace());
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
