using BO.Base;
using BO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENI_Projet_Sport.ViewModels
{
    public class CreateEditPOIViewModel : POIViewModel
    {
        public int? CategoryPOIId { get; set; }
        public List<SelectListItem> CategoryPOIsForSelectList { get; set; }

        public void InitLists()
        {
            var serviceLocator = ServiceLocator.Instance;
            var serviceCategoryPOI = serviceLocator.GetService<IServiceCategoryPOI>();
            this.CategoryPOIsForSelectList = serviceCategoryPOI.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
        }
    }
}