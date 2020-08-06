using System;
using System.Collections.Generic;

namespace CoffeeShops.Models.Json
{
    public class Invoice
    {
        public int id { get; set; }
        public Employee employee { get; set; }
        public int store_id { get; set; }
        public string created_date { get; set; }
        public Invoice_status status { get; set; }
        public Nullable<int> total { get; set; }
        //
        public List<Invoice_detail> details { get; set; }

        public static Invoice JsonConvert(invoices entity)
        {
            List<Invoice_detail> list = new List<Invoice_detail>();
            foreach (invoice_detail detail in entity.invoice_detail)
            {
                list.Add(Invoice_detail.JsonConvert(detail));
            }
            return new Invoice()
            {
                id = entity.id,
                employee = Employee.JsonConvert(entity.employees),
                created_date = entity.created_date.ToString(),
                status = Invoice_status.JsonConvert(entity.invoice_status),
                total = entity.total,
                store_id = entity.store_id.Value,
                //
                details = list
                //              
            };
        }
    }
}