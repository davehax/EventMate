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
        [Required]
        public string title;

        [Display(Name = "Location")]
        [Required]
        public string location;

        [Display(Name = "Description")]
        [Required]
        public string description;

        [Display(Name = "Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ssa}", ApplyFormatInEditMode = true)]
        public DateTime dateandtime;

        //[Display(Name = "Event Picture")]
        public byte[] eventpicture;
    }
}