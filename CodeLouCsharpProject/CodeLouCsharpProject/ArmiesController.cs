using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeLouCsharpProject.Models;

namespace CodeLouCsharpProject
{
    public class ArmiesController : Controller
    {
        private ArmyDataContext db = new ArmyDataContext();

        // GET: Armies
        public ActionResult Index()
        {
            return View(db.Armies.ToList());
        }

        // GET: Armies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Army army = db.Armies.Find(id);
            if (army == null)
            {
                return HttpNotFound();
            }
            return View(army);
        }

        // GET: Armies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArmyID,Ruleset,Faction,SquadCount,Points")] Army army)
        {
            if (ModelState.IsValid)
            {
                db.Armies.Add(army);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(army);
        }

        // GET: Armies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Army army = db.Armies.Find(id);
            if (army == null)
            {
                return HttpNotFound();
            }
            return View(army);
        }

        // POST: Armies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArmyID,Ruleset,Faction,SquadCount,Points")] Army army)
        {
            if (ModelState.IsValid)
            {
                db.Entry(army).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(army);
        }

        // GET: Armies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Army army = db.Armies.Find(id);
            if (army == null)
            {
                return HttpNotFound();
            }
            return View(army);
        }

        // POST: Armies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Army army = db.Armies.Find(id);
            db.Armies.Remove(army);
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
