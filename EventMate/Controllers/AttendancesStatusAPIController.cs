using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventMate.Models;
using System.Data.Entity;

namespace EventMate.Controllers
{
    public class AttendancesStatusAPIController : ApiController
    {
        private eventmateEntities db = new eventmateEntities();

        // GET api/AttendanceStatusAPI/All
        [HttpGet]
        public dynamic All()
        {
            // Use C# "dynamic" return type to allow us to serialize and return an anonymous type
            var allStatuses = db.attendancestatus.Select(s => new
            {
                s.id,
                s.status
            });

            return allStatuses;
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