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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace ENI_Projet_Sport.Controllers
{
    public class PersonController : Controller
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

        // GET: Person
        public ActionResult Index()
        {
            var lst = _servicePerson.GetAll();

            return View(lst.Select(p => p.Map<PersonViewModel>()));
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _servicePerson.GetById(id.Value);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person.Map<PersonViewModel>());
        }

        // GET: Person/Edit
        public ActionResult Edit()
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            var person = _servicePerson.GetById(user.Result.person.Id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person.Map<PersonViewModel>());
        }

        // POST: Person/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNumber,BirthDate,OwnerID,DateMAJ")] PersonViewModel personVM)
        {
            if (ModelState.IsValid)
            {

                var person = _servicePerson.GetById(personVM.Id);
                person.DateMAJ = DateTime.Now;
                person.BirthDate = personVM.BirthDate;
                person.FirstName = personVM.FirstName;
                person.LastName = personVM.LastName;
                person.PhoneNumber = personVM.PhoneNumber;

                _servicePerson.Update(person);
                _servicePerson.Commit();

                return RedirectToAction("..");
            }
            return View(personVM);
        }
        
    }
}
