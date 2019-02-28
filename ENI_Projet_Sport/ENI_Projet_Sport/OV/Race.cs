using ENI_Projet_Sport.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.OV
{
    public class Race: BaseOV
    {
        public string City { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public string Description { get; set; }
        public List<Inscription> Inscriptions { get; set; }
        //public List<Poi> Pois { get; set; }
        public float Price { get; set; }        
        public string Title { get; set; }
        public string ZipCode { get; set; }
    }
}