using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EventMate.Models
{
    [MetadataType(typeof(EventsMetadata))]
    public partial class events
    {
        [Display(Name = "Event Picture")]
        public HttpPostedFileBase EventPictureFile { get; set; }
    }

    public class EventsMetadata
    {
        [Display(Name = "Title")]
        public string title;

        [Display(Name = "Location")]
        public string location;

        [Display(Name = "Description")]
        public string description;

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime dateandtime;

        //[Display(Name = "Event Picture")]
        public byte[] eventpicture;
    }
}