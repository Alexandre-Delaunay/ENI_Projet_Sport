﻿using BO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO.Models
{
    public class DisplayConfiguration : BaseOV
    {
        public virtual UnitDistance UnitDistance { get; set; }
    }
}