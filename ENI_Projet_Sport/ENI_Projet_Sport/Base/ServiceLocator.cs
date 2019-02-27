using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENI_Projet_Sport.Base
{
    public class ServiceLocator: IServiceLocator
    {
        private IDictionary<object, object> services;

        internal ServiceLocator()
        {
            services = new Dictionary<object, object>();

            //this.services.Add(typeof(IServiceArme), new ServiceArme());            
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
    }
}
