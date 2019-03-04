using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO.Models;
using ENI_Projet_Sport.Models;
using BO.Services;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.ViewModels;
using BO.Base;

namespace ENI_Projet_Sport.Controllers
{
    public class RaceTypesController : Controller
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRaceType _serviceRaceType = _serviceLocator.GetService<IServiceRaceType>();

        // GET: RaceTypes
        public ActionResult Index()
        {
            var getAll = _serviceRaceType.GetAll().ToList();
            return View(getAll.Select(e => e.Map<ViewModels.RaceTypeViewModel>()).ToList());
        }

        // GET: RaceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RaceTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceTypeViewModel raceTypeVM)
        {
            if (ModelState.IsValid)
            {
                raceTypeVM.DateMAJ = DateTime.Now;
                _serviceRaceType.Add(raceTypeVM.Map<RaceType>());
                _serviceRaceType.Commit();
                return RedirectToAction("Index");
            }

            return View(raceTypeVM);
        }

        // GET: RaceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceType raceType = _serviceRaceType.GetById(id ?? 1);
            if (raceType == null)
            {
                return HttpNotFound();
            }
            return View(raceType.Map<RaceTypeViewModel>());
        }

        // POST: RaceTypes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceTypeViewModel raceTypeVM)
        {
            if (ModelState.IsValid)
            {
                raceTypeVM.DateMAJ = DateTime.Now;
                _serviceRaceType.Update(raceTypeVM.Map<RaceType>());
                _serviceRaceType.Commit();
                return RedirectToAction("Index");
            }
            return View(raceTypeVM);
        }

        // GET: RaceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceType raceType = _serviceRaceType.GetById(id ?? 1);
            if (raceType == null)
            {
                return HttpNotFound();
            }
            return View(raceType.Map<RaceTypeViewModel>());
        }

        // POST: RaceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaceType raceType = _serviceRaceType.GetById(id);
            _serviceRaceType.Delete(raceType);
            _serviceRaceType.Commit();

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
