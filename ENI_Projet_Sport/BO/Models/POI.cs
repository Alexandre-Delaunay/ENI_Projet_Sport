using BO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class POI : BaseOV
    {
        public virtual float Latitude { get; set; }
        public virtual float Longitude { get; set; }
        public virtual CategoryPOI CategoryPOI { get; set; }
    }
}
