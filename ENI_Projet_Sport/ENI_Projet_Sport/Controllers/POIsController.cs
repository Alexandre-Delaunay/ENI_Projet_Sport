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

namespace ENI_Projet_Sport.Controllers
{
    public class POIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: POIs
        public ActionResult Index()
        {
            return View(db.POIs.ToList());
        }

        // POST: POIs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(List<POI> POIs)
        {
            if (ModelState.IsValid)
            {
                //db.POIs.Add(POIs);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(POIs);
        }

        // GET: POIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POI pOI = db.POIs.Find(id);
            if (pOI == null)
            {
                return HttpNotFound();
            }
            return View(pOI);
        }

        // POST: POIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POI pOI = db.POIs.Find(id);
            db.POIs.Remove(pOI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
