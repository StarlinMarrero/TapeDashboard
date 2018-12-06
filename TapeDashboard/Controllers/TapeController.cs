using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TapeDashboard.Models;

namespace TapeDashboard.Controllers
{
    public class TapeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tape
        public ActionResult Index()
        {
            return View(db.Tapes.ToList());
        }

        // GET: Tape/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tape tape = db.Tapes.Find(id);
            if (tape == null)
            {
                return HttpNotFound();
            }
            return View(tape);
        }

        // GET: Tape/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tape/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TapeID,Formato,CantidadTotal,CantidadEnUso,CantidadDisponible,LabelFisico")] Tape tape)
        {
            if (ModelState.IsValid)
            {
                db.Tapes.Add(tape);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tape);
        }

        // GET: Tape/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tape tape = db.Tapes.Find(id);
            if (tape == null)
            {
                return HttpNotFound();
            }
            return View(tape);
        }

        // POST: Tape/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TapeID,Formato,CantidadTotal,CantidadEnUso,CantidadDisponible,LabelFisico")] Tape tape)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tape).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tape);
        }

        // GET: Tape/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tape tape = db.Tapes.Find(id);
            if (tape == null)
            {
                return HttpNotFound();
            }
            return View(tape);
        }

        // POST: Tape/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tape tape = db.Tapes.Find(id);
            db.Tapes.Remove(tape);
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
