using BO.Base;
using System;
using System.Collections.Generic;

namespace ENI_Projet_Sport.ViewModels
{
    public class RaceViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        public virtual string Name { get; set; }
        public virtual int PlacesNumber { get; set; }
        public virtual string City { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual float Price { get; set; }
        public virtual string Description { get; set; }
        public virtual List<POIViewModel> POIs { get; set; }
        public virtual List<PersonViewModel> Persons { get; set; }

        public RaceViewModel()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();

            POIs = new List<POIViewModel>();
            Persons = new List<PersonViewModel>();
        }
    }
}