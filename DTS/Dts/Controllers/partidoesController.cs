using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dts;

namespace Dts.Controllers
{
    public class partidoesController : Controller
    {
        private soccerdbEntities db = new soccerdbEntities();

        // GET: partidoes
        public ActionResult Index()
        {
            var partidoes = db.partidoes.Include(p => p.cancha);
            return View(partidoes.ToList());
        }

        // GET: partidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partido partido = db.partidoes.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: partidoes/Create
        public ActionResult Create()
        {
            ViewBag.cancha_idcancha = new SelectList(db.canchas, "idcancha", "cannombre");
            return View();
        }

        // POST: partidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "parid,partitulo,parhora,cancha_idcancha")] partido partido)
        {
            if (ModelState.IsValid)
            {
                db.partidoes.Add(partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cancha_idcancha = new SelectList(db.canchas, "idcancha", "cannombre", partido.cancha_idcancha);
            return View(partido);
        }

        // GET: partidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partido partido = db.partidoes.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.cancha_idcancha = new SelectList(db.canchas, "idcancha", "cannombre", partido.cancha_idcancha);
            return View(partido);
        }

        // POST: partidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "parid,partitulo,parhora,cancha_idcancha")] partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cancha_idcancha = new SelectList(db.canchas, "idcancha", "cannombre", partido.cancha_idcancha);
            return View(partido);
        }

        // GET: partidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partido partido = db.partidoes.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // POST: partidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            partido partido = db.partidoes.Find(id);
            db.partidoes.Remove(partido);
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
