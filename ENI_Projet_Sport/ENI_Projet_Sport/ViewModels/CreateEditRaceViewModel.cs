using BO.Base;
using BO.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENI_Projet_Sport.ViewModels
{
    public class CreateEditRaceViewModel : RaceViewModel
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRaceType _serviceRaceType = _serviceLocator.GetService<IServiceRaceType>();

        [Required, DisplayName("Type de course")]
        public string RaceTypeId { get; set; }

        public List<SelectListItem> RacesType { get; set; }

        public CreateEditRaceViewModel()
        {
            RacesType = _serviceRaceType.GetAll().Select(p => new SelectListItem
                                                {
                                                    Value = p.Id.ToString(),
                                                    Text = p.Name
                                                }).ToList();
            InitLists();
        }

        public void InitLists()
        {
            var serviceLocator = ServiceLocator.Instance;
            var servicePOI = serviceLocator.GetService<IServicePOI>();
        }


    }
}