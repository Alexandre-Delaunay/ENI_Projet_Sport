using ENI_Projet_Sport.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.OV
{
    public class ApplicationUser : BaseOV
    {
        public DateTime? BirthDate { get; set; }
        public ICollection<DisplayConfiguration> DisplayConfiguration {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}