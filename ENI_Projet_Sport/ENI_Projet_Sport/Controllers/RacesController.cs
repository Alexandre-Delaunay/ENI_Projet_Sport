﻿using System;
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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ENI_Projet_Sport.Helpers;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace ENI_Projet_Sport.Controllers
{
    public class RacesController : Controller
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
        private static IServiceRace _serviceRace = _serviceLocator.GetService<IServiceRace>();
        private static IServiceRaceType _serviceRaceType = _serviceLocator.GetService<IServiceRaceType>();
        private static IServicePOI _servicePOI = _serviceLocator.GetService<IServicePOI>();
        private static IServiceCategoryPOI _serviceCategoryPOI = _serviceLocator.GetService<IServiceCategoryPOI>();

        // GET: Races
        public ActionResult Index()
        {
            var getAll = _serviceRace.GetAll().ToList().Select(e => e.Map<ViewModels.RaceViewModel>()).ToList();

            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user.Result != null)
            {
                List<Race> UserRaces = user.Result.person.Races;
                var typeUnit = user.Result.displayConfiguration.TypeUnite;

                getAll.ForEach(r =>
                {
                    if (typeUnit.Equals(TypeUnit.Miles))
                    {
                        r.Distance = (float)UniteHelper.MeterToMiles(r.Distance);
                    }
                    else
                    {
                        r.Distance = (float)UniteHelper.MeterToKm(r.Distance);
                    }

                    if (UserRaces.Select(race => race.Id).Contains(r.Id))
                    {
                        r.isSubscribe = true;
                    }
                });
            }

            return View(getAll);
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

            var raceVM = race.Map<RaceViewModel>();

            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                var typeUnit = user.Result.displayConfiguration.TypeUnite;
                if (typeUnit.Equals(TypeUnit.Miles))
                {
                    raceVM.Distance = (float)UniteHelper.MeterToMiles(raceVM.Distance);
                }
                else
                {
                    raceVM.Distance = (float)UniteHelper.MeterToKm(raceVM.Distance);
                }
            }

            return View(raceVM);
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
            dynamic errorObj = new ExpandoObject();
            if (raceVM.POIs.Count() < 2)
                errorObj.POIs = "Le nombre de POI est insuffisant.";

            if (raceVM.City==null)
                errorObj.City = "Le champ Ville doit être renseigné.";

            if (DateTime.Compare(raceVM.DateRace, DateTime.Now) < 0)
                errorObj.DateRace = "La date de la course doit être supérieure ou égale à la date du jour.";

            if (raceVM.Name == null)
                errorObj.Name = "Le champ Nom de la course doit être renseigné.";

            if (raceVM.PlacesNumber <= 0)
                errorObj.PlacesNumber = "Le nombre de place doit être supérieur à 0.";

            if (raceVM.Price == 0)
                errorObj.Price = "Le prix de la course doit être supérieur à 0.";

            if (raceVM.RaceTypeId == null)
                errorObj.RaceTypeId = "Le champ Type de course doit être renseigné.";

            if (raceVM.ZipCode == null)
                errorObj.ZipCode = "Le champ Code postal doit être renseigné.";

            if (ModelState.IsValid)
            {
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
            }
            string json = new JavaScriptSerializer().Serialize(errorObj);
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, json);
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
            raceVM.POIs = race_from_db.POIs.Select(s => s.Map<POIViewModel>()).ToList();
            raceVM.Distance = race_from_db.Distance;

            raceVM.Map(race_from_db);
            _serviceRace.Commit();
            return RedirectToAction("index");
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
