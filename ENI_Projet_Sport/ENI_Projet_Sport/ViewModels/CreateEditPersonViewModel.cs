using BO.Base;
using BO.Models;
using BO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENI_Projet_Sport.ViewModels
{
    public class CreateEditPersonViewModel : PersonViewModel
    {
        public int? DisplayConfigurationId { get; set; }
        public List<SelectListItem> DisplayConfigurationsForSelectList { get; set; }

        public CreateEditPersonViewModel()
        {
        }

        public void InitLists()
        {
            var serviceLocator = ServiceLocator.Instance;
            var serviceDisplayConfiguration = serviceLocator.GetService<IServiceDisplayConfiguration>();
            this.DisplayConfigurationsForSelectList = serviceDisplayConfiguration.GetAll().Select(d => new SelectListItem
            {
                Text = d.TypeUnite.ToString(),
                Value = d.Id.ToString()
            }).ToList();
        }
    }
}