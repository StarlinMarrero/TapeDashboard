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
    public class RespaldosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Respaldos
        public ActionResult Index()
        {
            return View(db.Respaldos.ToList());
        }

        // GET: Respaldos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respaldos respaldos = db.Respaldos.Find(id);
            if (respaldos == null)
            {
                return HttpNotFound();
            }
            return View(respaldos);
        }

        // GET: Respaldos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Respaldos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RespaldoID,Secuencia,FechaInicio,FechaFin,Ubicacion,AplicaPolitica,Comentario")] Respaldos respaldos)
        {
            if (ModelState.IsValid)
            {
                db.Respaldos.Add(respaldos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(respaldos);
        }

        // GET: Respaldos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respaldos respaldos = db.Respaldos.Find(id);
            if (respaldos == null)
            {
                return HttpNotFound();
            }
            return View(respaldos);
        }

        // POST: Respaldos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RespaldoID,Secuencia,FechaInicio,FechaFin,Ubicacion,AplicaPolitica,Comentario")] Respaldos respaldos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respaldos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(respaldos);
        }

        // GET: Respaldos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respaldos respaldos = db.Respaldos.Find(id);
            if (respaldos == null)
            {
                return HttpNotFound();
            }
            return View(respaldos);
        }

        // POST: Respaldos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respaldos respaldos = db.Respaldos.Find(id);
            db.Respaldos.Remove(respaldos);
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
