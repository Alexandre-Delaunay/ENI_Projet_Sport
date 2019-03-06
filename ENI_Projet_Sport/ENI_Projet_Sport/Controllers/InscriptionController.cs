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
using Microsoft.AspNet.Identity.Owin;
using BO.Base;
using BO.Services;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Web.Helpers;

namespace ENI_Projet_Sport.Controllers
{
    public class InscriptionController : Controller
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
        private static IServicePerson _servicePerson = _serviceLocator.GetService<IServicePerson>();
        private static IServiceRace _serviceRace = _serviceLocator.GetService<IServiceRace>();

        [HttpPost]
        public JsonResult Create(int? id)
        {
            if (id==null)
            {
                return Json(HttpStatusCode.InternalServerError);
            }
            try
            {
                var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
                var person = _servicePerson.GetById(user.Result.person.Id);
                var race = _serviceRace.GetById(Convert.ToInt32(id));

                if (!person.Races.Contains(race))
                {
                    person.Races.Add(race);
                    _servicePerson.Update(person);
                    _servicePerson.Commit();
                }
                
                return Json(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw;
                //return Json(HttpStatusCode.InternalServerError);
            }
        }
        

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(HttpStatusCode.InternalServerError);
            }
            try
            {
                var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
                var person = _servicePerson.GetById(user.Result.person.Id);
                var race = _serviceRace.GetById(Convert.ToInt32(id));

                if (person.Races.Contains(race))
                {
                    person.Races.Remove(race);
                    _servicePerson.Commit();
                }

                return Json(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                //return Json(HttpStatusCode.InternalServerError);
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
