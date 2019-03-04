using BO.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENI_Projet_Sport.ViewModels
{
    public class CategoryPOIViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        [DisplayName("Date de mise à jour")]
        public virtual DateTime DateMAJ { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}