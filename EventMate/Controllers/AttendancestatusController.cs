using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventMate.Models;

namespace EventMate.Controllers
{
    public class AttendancestatusController : Controller
    {
        private eventmateEntities db = new eventmateEntities();

        // GET: Attendancestatus
        public ActionResult Index()
        {
            return View(db.attendancestatus.ToList());
        }

        // GET: Attendancestatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendancestatus attendancestatus = db.attendancestatus.Find(id);
            if (attendancestatus == null)
            {
                return HttpNotFound();
            }
            return View(attendancestatus);
        }

        // GET: Attendancestatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendancestatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,status")] attendancestatus attendancestatus)
        {
            if (ModelState.IsValid)
            {
                db.attendancestatus.Add(attendancestatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendancestatus);
        }

        // GET: Attendancestatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendancestatus attendancestatus = db.attendancestatus.Find(id);
            if (attendancestatus == null)
            {
                return HttpNotFound();
            }
            return View(attendancestatus);
        }

        // POST: Attendancestatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,status")] attendancestatus attendancestatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendancestatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendancestatus);
        }

        // GET: Attendancestatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendancestatus attendancestatus = db.attendancestatus.Find(id);
            if (attendancestatus == null)
            {
                return HttpNotFound();
            }
            return View(attendancestatus);
        }

        // POST: Attendancestatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attendancestatus attendancestatus = db.attendancestatus.Find(id);
            db.attendancestatus.Remove(attendancestatus);
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
