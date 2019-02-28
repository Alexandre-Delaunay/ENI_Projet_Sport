using ENI_Projet_Sport.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.OV
{
    public class Inscription: BaseOV
    {
        public float Amount { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public int Number { get; set; }
        //public List<Poi> Positions { get; set; }        
        public int RaceId { get; set; }        
        public Race Race { get; set; }
        //public TypeInscription TypeInscription { get; set; }
    }
}