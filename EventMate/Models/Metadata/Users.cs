using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

// Approach borrowed from here
// https://stackoverflow.com/a/4916085
namespace EventMate.Models
{
    [MetadataType(typeof(UsersMetadata))]
    public partial class users
    {
        // Empty partial class
    }

    public class UsersMetadata
    {
        [Display(Name = "First Name")]
        public string firstname;

        [Display(Name = "Last Name")]
        public string lastname;

        [Display(Name = "Title")]
        public string title;

        [Display(Name = "Email")]
        public string email;

        [Display(Name = "Display Name")]
        public string displayname;
    }
}