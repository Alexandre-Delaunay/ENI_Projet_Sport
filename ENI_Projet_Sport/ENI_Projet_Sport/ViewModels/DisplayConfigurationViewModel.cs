using BO.Base;
using BO.Models;
using System;

namespace ENI_Projet_Sport.ViewModels
{
    public class DisplayConfigurationViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        public virtual TypeUnit TypeUnite { get; set; }
    }
}