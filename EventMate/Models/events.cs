//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventMate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class events
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public events()
        {
            this.attendance = new HashSet<attendance>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public System.DateTime dateandtime { get; set; }
        public byte[] eventpicture { get; set; }
        public string eventpictureurl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attendance> attendance { get; set; }
    }
}
