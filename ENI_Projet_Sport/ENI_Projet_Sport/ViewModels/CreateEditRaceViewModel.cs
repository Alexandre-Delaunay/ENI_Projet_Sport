using BO.Base;
using BO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENI_Projet_Sport.ViewModels
{
    public class CreateEditRaceViewModel : RaceViewModel
    {

        public CreateEditRaceViewModel()
        {
            InitLists();
        }

        public void InitLists()
        {
            var serviceLocator = ServiceLocator.Instance;
            var servicePOI = serviceLocator.GetService<IServicePOI>();
        }
    }
}