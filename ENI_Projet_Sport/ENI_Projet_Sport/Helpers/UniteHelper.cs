using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.Helpers
{
    public sealed class UniteHelper
    {
        public static double KmPerHourToMiles(double kmph)
        {
            return 0.621371 * kmph;
        }

        public static double MilesToKmPerHour(double miles)
        {
            return 1.60934 * miles;
        }
    }
}