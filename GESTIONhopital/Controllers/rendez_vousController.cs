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
    public class rendez_vousController : Controller
    {
        private hopitalcontext db = new hopitalcontext();

        // GET: rendez_vous
        public ActionResult Index()
        {
            var rendez_Vous = db.rendez_Vous.Include(r => r.Medcin).Include(r => r.Passion);
            return View(rendez_Vous.ToList());
        }

        // GET: rendez_vous/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rendez_vous rendez_vous = db.rendez_Vous.Find(id);
            if (rendez_vous == null)
            {
                return HttpNotFound();
            }
            return View(rendez_vous);
        }

        // GET: rendez_vous/Create
        public ActionResult Create()
        {
            ViewBag.medcinid = new SelectList(db.medcins, "id", "name");
            ViewBag.passionid = new SelectList(db.passions, "id", "name");
            return View();
        }

        // POST: rendez_vous/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,passionid,medcinid")] rendez_vous rendez_vous)
        {
            if (ModelState.IsValid)
            {
                db.rendez_Vous.Add(rendez_vous);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medcinid = new SelectList(db.medcins, "id", "name", rendez_vous.medcinid);
            ViewBag.passionid = new SelectList(db.passions, "id", "name", rendez_vous.passionid);
            return View(rendez_vous);
        }

        // GET: rendez_vous/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rendez_vous rendez_vous = db.rendez_Vous.Find(id);
            if (rendez_vous == null)
            {
                return HttpNotFound();
            }
            ViewBag.medcinid = new SelectList(db.medcins, "id", "name", rendez_vous.medcinid);
            ViewBag.passionid = new SelectList(db.passions, "id", "name", rendez_vous.passionid);
            return View(rendez_vous);
        }

        // POST: rendez_vous/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,passionid,medcinid")] rendez_vous rendez_vous)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rendez_vous).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medcinid = new SelectList(db.medcins, "id", "name", rendez_vous.medcinid);
            ViewBag.passionid = new SelectList(db.passions, "id", "name", rendez_vous.passionid);
            return View(rendez_vous);
        }

        // GET: rendez_vous/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rendez_vous rendez_vous = db.rendez_Vous.Find(id);
            if (rendez_vous == null)
            {
                return HttpNotFound();
            }
            return View(rendez_vous);
        }

        // POST: rendez_vous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rendez_vous rendez_vous = db.rendez_Vous.Find(id);
            db.rendez_Vous.Remove(rendez_vous);
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
