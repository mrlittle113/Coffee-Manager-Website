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
    
    public partial class invoices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invoices()
        {
            this.invoice_detail = new HashSet<invoice_detail>();
        }
    
        public int id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> store_id { get; set; }
        public System.DateTime created_date { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> total { get; set; }
    
        public virtual employees employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice_detail> invoice_detail { get; set; }
        public virtual invoice_status invoice_status { get; set; }
        public virtual stores stores { get; set; }
    }
}
