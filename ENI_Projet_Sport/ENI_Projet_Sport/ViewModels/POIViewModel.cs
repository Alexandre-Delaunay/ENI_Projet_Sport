using BO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.ViewModels
{
    public class POIViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        public virtual float Latitude { get; set; }
        public virtual float Longitude { get; set; }
        public virtual CategoryPOIViewModel CategoryPOI { get; set; }
    }
}