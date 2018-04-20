using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventMate.Models
{
    /// <summary>
    /// Proxy class that will be used facilitate populating or modifying multiple database rows
    /// </summary>
    [Serializable]
    public class AttendanceProxy
    {
        // Empty constructor for Serialisation
        public AttendanceProxy() { } 

        public int eventId { get; set; }
        public UserAttendanceProxy[] userAttendanceProxies { get; set; }
    }

    /// <summary>
    /// Proxy class that will be used facilitate populating or modifying multiple database rows
    /// </summary>
    [Serializable]
    public class UserAttendanceProxy
    {
        public UserAttendanceProxy() { }
        public int userId { get; set; }
        public int statusId { get; set; }
    }
}