using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.Helpers
{
    public sealed class UniteHelper
    {
        public static double MeterToKm(double meter)
        {
            return meter * 0.001;
        }

        public static double MeterToMiles(double meter)
        {
            return meter * 0.000621;
        }
    }
}