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
using BO.Base;
using BO.Services;
using ENI_Projet_Sport.Extensions;
using ENI_Projet_Sport.ViewModels;

namespace ENI_Projet_Sport.Controllers
{
    public class RacesController : Controller
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRace _serviceRace = _serviceLocator.GetService<IServiceRace>();
        private static IServicePOI _servicePOI = _serviceLocator.GetService<IServicePOI>();

        // GET: Races
        public ActionResult Index()
        {
            var getAll = _serviceRace.GetAll().ToList();
            return View(getAll.Select(e => e.Map<ViewModels.RaceViewModel>()).ToList());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = _serviceRace.GetById(id ?? 1);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race.Map<ViewModels.RaceViewModel>());
        }

        // GET: Races/Create
        public ActionResult Create()
        {
            var vm = new CreateEditRaceViewModel();

            return View(vm);
        }

        // POST: Races/Create
        [HttpPost]
        public ActionResult Create(CreateEditRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                raceVM.DateMAJ = DateTime.Now;
                var race = raceVM.Map<Race>();

                race.POIs.ForEach(p =>
                {                                        
                    p.DateMAJ = DateTime.Now;
                });

                _serviceRace.Add(race);
                _serviceRace.Commit();

                return RedirectToAction("Index");
            }

            return View(raceVM);
        }

        //// GET: Races/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Race race = db.Races.Find(id);
        //    if (race == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(race);
        //}

        //// POST: Races/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,PlacesNumber,City,ZipCode,Price,Description,DateMAJ")] Race race)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(race).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(race);
        //}

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = _serviceRace.GetById(id ?? 1);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race.Map<RaceViewModel>());
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = _serviceRace.GetById(id);
            _serviceRace.Delete(race);
            _serviceRace.Commit();
            return RedirectToAction("Index");
        }
    }
}
