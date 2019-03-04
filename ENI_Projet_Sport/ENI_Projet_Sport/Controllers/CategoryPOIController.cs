﻿using System;
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
using ENI_Projet_Sport.ViewModels;
using ENI_Projet_Sport.Extensions;

namespace ENI_Projet_Sport.Controllers
{
    public class CategoryPOIController : Controller
    {
        private ServiceCategoryPOI serviceCategoryPOI = new ServiceCategoryPOI();

        // GET: CategoryPOI
        public ActionResult Index()
        {
            return View(serviceCategoryPOI.GetAll().Select(c => c.Map<CategoryPOIViewModel>()).ToList());
        }

        // GET: CategoryPOI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryPOI/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryPOIViewModel categoryPOIVM)
        {
            if (ModelState.IsValid)
            {
                categoryPOIVM.DateMAJ = DateTime.Now;
                serviceCategoryPOI.Add(categoryPOIVM.Map<CategoryPOI>());
                serviceCategoryPOI.Commit();
                return RedirectToAction("Index");
            }

            return View(categoryPOIVM);
        }

        // GET: CategoryPOI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryPOI categoryPOI = serviceCategoryPOI.GetById(Convert.ToInt32(id));
            if (categoryPOI == null)
            {
                return HttpNotFound();
            }
            return View(categoryPOI.Map<CategoryPOIViewModel>());
        }

        // POST: CategoryPOI/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryPOIViewModel categoryPOIVM)
        {
            if (ModelState.IsValid)
            {
                categoryPOIVM.DateMAJ = DateTime.Now;
                serviceCategoryPOI.Update(categoryPOIVM.Map<CategoryPOI>());
                serviceCategoryPOI.Commit();
                return RedirectToAction("Index");
            }
            return View(categoryPOIVM);
        }

        // GET: CategoryPOI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryPOI categoryPOI = serviceCategoryPOI.GetById(Convert.ToInt32(id));
            if (categoryPOI == null)
            {
                return HttpNotFound();
            }
            return View(categoryPOI.Map<CategoryPOIViewModel>());
        }

        // POST: CategoryPOI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryPOI categoryPOI = serviceCategoryPOI.GetById(id);
            serviceCategoryPOI.Delete(categoryPOI);
            serviceCategoryPOI.Commit();
            return RedirectToAction("Index");
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
