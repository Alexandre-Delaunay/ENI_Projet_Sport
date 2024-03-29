﻿using System;
using System.Web;
using System.Web.Mvc;
using BO.Base;
using BO.Models;
using BO.Services;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Web.Optimization;

namespace ENI_Projet_Sport.Controllers
{
    [Authorize]
    public class DisplayConfigurationController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceDisplayConfiguration _serviceDisplayConfiguration = _serviceLocator.GetService<IServiceDisplayConfiguration>();

        // GET: DisplayConfiguration/Edit
        public ActionResult Edit()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            DisplayConfiguration displayConfiguration = _serviceDisplayConfiguration.GetById(user.Result.displayConfiguration.Id);
            if (displayConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(displayConfiguration.Map<DisplayConfigurationViewModel>());
        }

        // POST: DisplayConfiguration/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DisplayConfigurationViewModel displayConfigurationVM)
        {
            if (ModelState.IsValid)
            {
                var displayConfig = _serviceDisplayConfiguration.GetById(displayConfigurationVM.Id);
                displayConfig.DateMAJ = DateTime.Now;
                displayConfig.TypeUnite = displayConfigurationVM.TypeUnite;
                displayConfig.IsDarkTheme = displayConfigurationVM.IsDarkTheme;

                _serviceDisplayConfiguration.Update(displayConfig);
                _serviceDisplayConfiguration.Commit();

                BundleConfig.RegisterBundles(BundleTable.Bundles, displayConfig.IsDarkTheme);

                return RedirectToAction("..");
            }
            return View(displayConfigurationVM);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
