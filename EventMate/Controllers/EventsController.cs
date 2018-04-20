using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventMate.Models;
using System.IO;

namespace EventMate.Controllers
{
    public class EventsController : Controller
    {
        private eventmateEntities db = new eventmateEntities();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }

            // Load additional data from the database to provide additional context for end users
            List<view_eventattendees> eventAttendees = db.view_eventattendees.Where(e => e.eventId == id).ToList();
            ViewBag.EventAttendees = eventAttendees;

            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,location,description,dateandtime,eventpicture,EventPictureFile")] events events)
        {
            if (ModelState.IsValid)
            {
                SaveEventPictureAndUpdateEvent(ref events);

                db.events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Invite/5
        [HttpGet]
        public ActionResult Invite(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,location,description,dateandtime,eventpicture,EventPictureFile,eventpictureurl")] events events)
        {
            if (ModelState.IsValid)
            {
                SaveEventPictureAndUpdateEvent(ref events);

                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            events events = db.events.Find(id);
            db.events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// On Add or Edit, if the "EventPictureFile" is provided then this
        /// function will save it to disk and update the "eventpictureurl" property
        /// of the events class instance.
        /// </summary>
        /// <param name="events"></param>
        private void SaveEventPictureAndUpdateEvent(ref events events)
        {
            if (events.EventPictureFile != null)
            {
                byte[] buffer = new byte[events.EventPictureFile.ContentLength];
                events.EventPictureFile.InputStream.Read(buffer, 0, events.EventPictureFile.ContentLength);

                // ensure folder exists
                if (!Directory.Exists(Server.MapPath("~/uploads"))) { Directory.CreateDirectory(Server.MapPath("~/uploads")); }
                if (!Directory.Exists(Server.MapPath("~/uploads/events"))) { Directory.CreateDirectory(Server.MapPath("~/uploads/events")); }

                // save file to disk
                string fileName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddhhmmss"), events.EventPictureFile.FileName);
                string filePath = string.Format("/uploads/events/{0}", fileName);
                string mappedFilePath = Server.MapPath(string.Format("~{0}", filePath));
                events.EventPictureFile.SaveAs(mappedFilePath);

                // update model
                events.eventpictureurl = filePath;
            }
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
