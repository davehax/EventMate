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
    public class AttendancesController : Controller
    {
        private eventmateEntities db = new eventmateEntities();

        // GET: Attendances
        public ActionResult Index()
        {
            var attendance = db.attendance.Include(a => a.events).Include(a => a.attendancestatus).Include(a => a.users);
            return View(attendance.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.fkevent = new SelectList(db.events, "id", "title");
            ViewBag.fkstatus = new SelectList(db.attendancestatus, "id", "status");
            ViewBag.fkuser = new SelectList(db.users, "id", "firstname");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fkevent,fkuser,fkstatus")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.attendance.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkevent = new SelectList(db.events, "id", "title", attendance.fkevent);
            ViewBag.fkstatus = new SelectList(db.attendancestatus, "id", "status", attendance.fkstatus);
            ViewBag.fkuser = new SelectList(db.users, "id", "firstname", attendance.fkuser);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkevent = new SelectList(db.events, "id", "title", attendance.fkevent);
            ViewBag.fkstatus = new SelectList(db.attendancestatus, "id", "status", attendance.fkstatus);
            ViewBag.fkuser = new SelectList(db.users, "id", "firstname", attendance.fkuser);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fkevent,fkuser,fkstatus")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkevent = new SelectList(db.events, "id", "title", attendance.fkevent);
            ViewBag.fkstatus = new SelectList(db.attendancestatus, "id", "status", attendance.fkstatus);
            ViewBag.fkuser = new SelectList(db.users, "id", "firstname", attendance.fkuser);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attendance attendance = db.attendance.Find(id);
            db.attendance.Remove(attendance);
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
