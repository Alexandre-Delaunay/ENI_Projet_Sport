using BO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class CategoryPOI : BaseOV
    {
        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}