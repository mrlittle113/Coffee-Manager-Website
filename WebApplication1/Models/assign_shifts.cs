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
    
    public partial class assign_shifts
    {
        public int id { get; set; }
        public Nullable<int> store_id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> shift_id { get; set; }
        public Nullable<int> week_id { get; set; }
    
        public virtual stores stores { get; set; }
        public virtual employees employees { get; set; }
        public virtual shifts shifts { get; set; }
        public virtual shifts_week shifts_week { get; set; }
    }
}
