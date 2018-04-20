using EventMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.Entity;

namespace EventMate.Controllers
{
    [Serializable]
    public class ComplexType1
    {
        public ComplexType1() { }
        string Name { get; set; }
    }

    public class AttendancesAPIController : ApiController
    {
        private eventmateEntities db = new eventmateEntities();

        // POST: api/AttendancesAPI/AddOrEditMultiple
        [HttpPost, Route("api/AttendancesAPI/AddOrEditMultiple")]
        [ActionName("AddOrEditMultiple")]
        public HttpResponseMessage AddOrEditMultiple([FromBody]JToken attendanceProxy)
        {
            // JToken as a parameter type allows us to accept JSON
            // We can then deserialise manually and handle errors
            try
            {
                AttendanceProxy ap = attendanceProxy.ToObject<AttendanceProxy>();

                // There are no items to add/update so return
                if (ap.userAttendanceProxies.Length == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                // Find the event referenced
                events evt = db.events.Find(ap.eventId);

                // Unable to find event, return HTTP500
                if (evt == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, string.Format("Event with id:{0} not found", ap.eventId));
                }

                foreach (UserAttendanceProxy uap in ap.userAttendanceProxies)
                {
                    // Do we add or update?
                    attendance a = db.attendance.FirstOrDefault(x => x.fkevent == ap.eventId && x.fkuser == uap.userId);
                    if (a == null)
                    {
                        // new attendance record
                        attendance newAttendance = new attendance();
                        newAttendance.fkevent = ap.eventId;
                        newAttendance.fkuser = uap.userId;
                        newAttendance.fkstatus = uap.statusId;
                        db.attendance.Add(newAttendance);
                    }
                    else
                    {
                        // update existing attendance record
                        a.fkstatus = uap.statusId;
                    }
                }

                // Commit changes
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
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