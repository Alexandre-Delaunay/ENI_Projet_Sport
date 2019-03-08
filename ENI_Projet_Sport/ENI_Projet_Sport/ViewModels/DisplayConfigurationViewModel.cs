using BO.Base;
using BO.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENI_Projet_Sport.ViewModels
{
    public class DisplayConfigurationViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        [DisplayName("Date de mise à jour")]
        public virtual DateTime DateMAJ { get; set; }
        [Required, DisplayName("Unité utilisée")]
        public virtual TypeUnit TypeUnite { get; set; }
        [DisplayName("Dark mode")]
        public virtual bool IsDarkTheme { get; set; }

    }
}