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

namespace ENI_Projet_Sport.Controllers
{
    public class PersonController : Controller
    {
        private static ServiceLocator _serviceLocator = ServiceLocator.Instance;
        private static IServicePerson _servicePerson = _serviceLocator.GetService<IServicePerson>();

        // GET: Person
        public ActionResult Index()
        {
            var lst = _servicePerson.GetAll();

            return View(lst);
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

            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PhoneNumber,BirthDate,OwnerID,DateMAJ")] Person person)
        {
            if (ModelState.IsValid)
            {
                _servicePerson.Add(person);
                _servicePerson.Commit();

                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
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

            return View(person);
        }

        // POST: Person/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNumber,BirthDate,OwnerID,DateMAJ")] Person person)
        {
            if (ModelState.IsValid)
            {
                _servicePerson.Update(person);
                _servicePerson.Commit();

                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
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

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var person = _servicePerson.GetById(id);
            _servicePerson.Delete(person);
            _servicePerson.Commit();

            return RedirectToAction("Index");
        }
    }
}
