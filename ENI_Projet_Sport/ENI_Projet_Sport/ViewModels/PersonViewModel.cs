using BO.Base;
using BO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENI_Projet_Sport.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        [Required, DisplayName("Prénom")]
        public virtual string FirstName { get; set; }
        [Required, DisplayName("Nom")]
        public virtual string LastName { get; set; }
        [DisplayName("Numéro de téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0]{1})([0-9]{1})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{2})[-. ]?([0-9]{2})[-. ]?([0-9]{2})$", ErrorMessage = "Ce n'est pas un numéro de téléphone valide")]
        public virtual string PhoneNumber { get; set; }
        [Required, DisplayName("Date de naissance")]
        [DataType(DataType.Date)]
        public virtual DateTime BirthDate { get; set; }
        public virtual List<Race> Races { get; set; }
        public PersonViewModel()
        {
            Initialize();
        }
    }
}