﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dacnEntities : DbContext
    {
        public dacnEntities()
            : base("name=dacnEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<absent_history> absent_history { get; set; }
        public virtual DbSet<assign_shifts> assign_shifts { get; set; }
        public virtual DbSet<employees> employees { get; set; }
        public virtual DbSet<invoice_detail> invoice_detail { get; set; }
        public virtual DbSet<invoices> invoices { get; set; }
        public virtual DbSet<ingredients> ingredients { get; set; }
        public virtual DbSet<product_type> product_type { get; set; }
        public virtual DbSet<products> products { get; set; }
        public virtual DbSet<recipe_ingredients> recipe_ingredients { get; set; }
        public virtual DbSet<report_detail> report_detail { get; set; }
        public virtual DbSet<reports> reports { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<shifts> shifts { get; set; }
        public virtual DbSet<stores> stores { get; set; }
        public virtual DbSet<warehouses> warehouses { get; set; }
        public virtual DbSet<invoice_status> invoice_status { get; set; }
        public virtual DbSet<shifts_week> shifts_week { get; set; }
    }
}
