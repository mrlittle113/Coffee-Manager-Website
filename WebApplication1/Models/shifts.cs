//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeShops.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class shifts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public shifts()
        {
            this.assign_shifts = new HashSet<assign_shifts>();
        }
    
        public int id { get; set; }
        public string shift_time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assign_shifts> assign_shifts { get; set; }
    }
}
