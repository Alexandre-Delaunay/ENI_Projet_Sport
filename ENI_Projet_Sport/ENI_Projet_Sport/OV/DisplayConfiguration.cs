﻿using ENI_Projet_Sport.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.OV
{
    public class DisplayConfiguration: BaseOV
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string DeviceName { get; set; }
        public Guid Guid { get; set; }
        public bool SpeedAvg { get; set; }
        public bool SpeedMax { get; set; }
        public UnitDistance UnitDistance { get; set; }
    }
}