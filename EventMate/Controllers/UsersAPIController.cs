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
    public class UsersAPIController : ApiController
    {
        private eventmateEntities db = new eventmateEntities();

        // GET api/UsersAPI/All
        // https://www.strathweb.com/2012/03/serializing-entity-framework-objects-to-json-in-asp-net-web-api/
        [HttpGet]
        public dynamic All()
        {
            // Use C# "dynamic" return type to let us return an anonymous type from the LINQ to SQL query
            var allUsers = db.users.Select(u => new {
                u.id,
                u.title,
                u.firstname,
                u.lastname,
                u.displayname,
                u.email
            });

            return allUsers;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}