using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO.Base;
using BO.Models;
using BO.Services;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.ViewModels;

namespace ENI_Projet_Sport.Controllers
{
    public class DisplayConfigurationController : Controller
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceDisplayConfiguration _serviceDisplayConfiguration = _serviceLocator.GetService<IServiceDisplayConfiguration>();

        // GET: DisplayConfiguration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisplayConfiguration displayConfiguration = _serviceDisplayConfiguration.GetById(Convert.ToInt32(id));
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
                displayConfigurationVM.DateMAJ = DateTime.Now;
                _serviceDisplayConfiguration.Update(displayConfigurationVM.Map<DisplayConfiguration>());
                _serviceDisplayConfiguration.Commit();
                return RedirectToAction("Index");
            }
            return View(displayConfigurationVM);
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }*/
            base.Dispose(disposing);
        }
    }
}
