using BO.Base;
using System;

namespace ENI_Projet_Sport.ViewModels
{
    public class CategoryPOIViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        public virtual string Name { get; set; }
    }
}