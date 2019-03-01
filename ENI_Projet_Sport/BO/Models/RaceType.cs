using BO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class RaceType : BaseOV
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}
