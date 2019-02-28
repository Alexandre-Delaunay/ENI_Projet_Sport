using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.Helpers
{
    public sealed class UniteHelper
    {
        public static double KmPerHourToMeterPerSecond(double kmph)
        {
            return 0.277778 * kmph;
        }

        public static double MeterPerSecondToKmPerHour(double mps)
        {
            return 3.6 * mps;
        }
    }
}