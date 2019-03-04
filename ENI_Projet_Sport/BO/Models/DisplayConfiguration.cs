using BO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class DisplayConfiguration : BaseOV
    {
        public TypeUnit TypeUnite { get; set; }
        public virtual Person Person { get; set; }
    }
    public enum TypeUnit
    {
        [Description("KmPerHour")]
        KmPerHour,
        [Description("MeterPerHour")]
        MeterPerHour
    }
}