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
    
    public partial class report_detail
    {
        public int id { get; set; }
        public Nullable<int> report_id { get; set; }
        public string reason { get; set; }
        public Nullable<int> price { get; set; }
    
        public virtual reports reports { get; set; }
    }
}
