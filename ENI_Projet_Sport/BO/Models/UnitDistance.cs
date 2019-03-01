﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class UnitDistance
    {
        public double Speed { get; set; }
        public TypeUnit TypeUnite { get; set; }
    }

    public enum TypeUnit
    {
        KmPerHour,
        MeterPerHour
    }
}