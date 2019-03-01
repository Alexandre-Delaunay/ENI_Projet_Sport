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
        public List<int> POIsIds { get; set; }
        public virtual List<SelectListItem> POIForSelectList { get; set; }

        public CreateEditRaceViewModel()
        {
            this.POIsIds = new List<int>();
        }

        public void InitLists()
        {
            var serviceLocator = ServiceLocator.Instance;
            var servicePOI = serviceLocator.GetService<IServicePOI>();
            this.POIForSelectList = servicePOI.GetAll().Select(p => new SelectListItem
            {
                Text = string.Format("{0} (lat : {1} - long : {2})", p.CategoryPOI.Name, p.Latitude, p.Longitude),
                Value = p.Id.ToString()
            }).ToList();
        }
    }
}