using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.OV
{
    public class UnitDistance
    {
        public double Speed { get; set; }
        public TypeUnit TypeUnite { get; set; }
    }

    public enum TypeUnit
    {
        None,
        KmPerHour,
        MeterPerHour
    }
}