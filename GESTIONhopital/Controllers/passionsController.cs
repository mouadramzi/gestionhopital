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
    public class passionsController : Controller
    {
        private hopitalcontext db = new hopitalcontext();

        // GET: passions
        public ActionResult Index()
        {
            return View(db.passions.ToList());
        }

        // GET: passions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            passion passion = db.passions.Find(id);
            if (passion == null)
            {
                return HttpNotFound();
            }
            return View(passion);
        }

        // GET: passions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: passions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,prenom,email,maladie,phone,adresse")] passion passion)
        {
            if (ModelState.IsValid)
            {
                db.passions.Add(passion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passion);
        }

        // GET: passions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            passion passion = db.passions.Find(id);
            if (passion == null)
            {
                return HttpNotFound();
            }
            return View(passion);
        }

        // POST: passions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,prenom,email,maladie,phone,adresse")] passion passion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passion);
        }

        // GET: passions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            passion passion = db.passions.Find(id);
            if (passion == null)
            {
                return HttpNotFound();
            }
            return View(passion);
        }

        // POST: passions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            passion passion = db.passions.Find(id);
            db.passions.Remove(passion);
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
