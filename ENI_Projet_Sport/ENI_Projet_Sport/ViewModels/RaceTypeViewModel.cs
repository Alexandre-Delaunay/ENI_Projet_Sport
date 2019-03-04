using BO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENI_Projet_Sport.ViewModels
{
    public class RaceTypeViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }

        [Required, MaxLength(50), DisplayName("Type de course")]
        public virtual string Name { get; set; }
    }
}