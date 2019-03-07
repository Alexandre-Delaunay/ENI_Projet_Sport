using BO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace ENI_Projet_Sport.ViewModels
{
    public class RaceViewModel : BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateMAJ { get; set; }
        [Required, DisplayName("Nom")]
        public virtual string Name { get; set; }
        [Required, DisplayName("Places")]
        public virtual int PlacesNumber { get; set; }
        [Required, DisplayName("Ville")]
        public virtual string City { get; set; }
        [Required, DisplayName("Code Postal")]
        public virtual string ZipCode { get; set; }
        [Required, DisplayName("Prix")]
        public virtual float Price { get; set; }
        public virtual string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required, DisplayName("Date")]
        public virtual DateTime DateRace { get; set; }
        [Required, DisplayName("Type de course")]
        public virtual RaceTypeViewModel RaceType { get; set; }
        public virtual List<POIViewModel> POIs { get; set; }
        public virtual List<PersonViewModel> Persons { get; set; }
        public virtual float Distance { get; set; }
        public virtual bool isSubscribe { get; set; }

        public RaceViewModel()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();

            this.POIs = new List<POIViewModel>();
            this.Persons = new List<PersonViewModel>();
        }
    }
}