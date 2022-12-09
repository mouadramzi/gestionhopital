using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GESTIONhopital.Models;

namespace GESTIONhopital.Controllers
{
    public class MedcinsController : Controller
    {
        private hopitalcontext db = new hopitalcontext();

        // GET: Medcins
        public ActionResult Index()
        {
            return View(db.medcins.ToList());
        }

        // GET: Medcins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medcin medcin = db.medcins.Find(id);
            if (medcin == null)
            {
                return HttpNotFound();
            }
            return View(medcin);
        }

        // GET: Medcins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medcins/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,prenom,email,specialite,phone")] Medcin medcin)
        {
            if (ModelState.IsValid)
            {
                db.medcins.Add(medcin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medcin);
        }

        // GET: Medcins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medcin medcin = db.medcins.Find(id);
            if (medcin == null)
            {
                return HttpNotFound();
            }
            return View(medcin);
        }

        // POST: Medcins/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,prenom,email,specialite,phone")] Medcin medcin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medcin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medcin);
        }

        // GET: Medcins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medcin medcin = db.medcins.Find(id);
            if (medcin == null)
            {
                return HttpNotFound();
            }
            return View(medcin);
        }

        // POST: Medcins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medcin medcin = db.medcins.Find(id);
            db.medcins.Remove(medcin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
