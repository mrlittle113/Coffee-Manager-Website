using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShops.Models.Json
{
    public class Invoice_status
    {
        public int id { get; set; }
        public string name { get; set; }

        public static Invoice_status JsonConvert(invoice_status entity)
        {
            return new Invoice_status()
            {
                id = entity.id,
                name = entity.name
            };
        }
    }
}