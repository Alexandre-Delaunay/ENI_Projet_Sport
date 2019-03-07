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
using System.Net.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENI_Projet_Sport.Controllers
{
    public class RacesController : Controller
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServiceRace _serviceRace = _serviceLocator.GetService<IServiceRace>();
        private static IServiceRaceType _serviceRaceType = _serviceLocator.GetService<IServiceRaceType>();
        private static IServicePOI _servicePOI = _serviceLocator.GetService<IServicePOI>();
        private static IServiceCategoryPOI _serviceCategoryPOI = _serviceLocator.GetService<IServiceCategoryPOI>();

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
            return View(new CreateEditRaceViewModel());
        }

        // POST: Races/Create
        [HttpPost]
        public ActionResult Create(CreateEditRaceViewModel raceVM)
        {
            raceVM.DateRace = DateTime.Now;
            raceVM.DateMAJ = DateTime.Now;
            Race race = raceVM.Map<Race>();

            var category = _serviceCategoryPOI.GetAll().Where(c => c.Name.Equals("Checkpoint")).FirstOrDefault();

            race.POIs.ForEach(p =>
            {                                        
                p.DateMAJ = DateTime.Now;
                p.CategoryPOI = category;
            });

            category = _serviceCategoryPOI.GetAll().Where(c => c.Name.Equals("Départ")).FirstOrDefault();
            race.POIs.First().CategoryPOI = category;
            category = _serviceCategoryPOI.GetAll().Where(c => c.Name.Equals("Arrivée")).FirstOrDefault();
            race.POIs.Last().CategoryPOI = category;

            _serviceRace.Add(race);
            _serviceRace.Commit();
            return View(raceVM);
            //return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
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
            return View(race.Map<CreateEditRaceViewModel>());
        }

        // POST: Races/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditRaceViewModel raceVM)
        {
            raceVM.DateMAJ = DateTime.Now;

            Race race_from_db = _serviceRace.GetById(raceVM.Id);
            raceVM.Map(race_from_db);
            _serviceRace.Commit();
            return View(raceVM);
        }

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
