using System;

namespace CoffeeShops.Models.Json
{
    public class Invoice_detail
    {
        public int id { get; set; }
        public Product product { get; set; }
        public Nullable<int> quantity { get; set; }

        public static Invoice_detail JsonConvert(invoice_detail entity)
        {
            return new Invoice_detail()
            {
                id = entity.id,
                product = Product.JsonConvert(entity.products),
                quantity = entity.quantity
            };
        }
    }
}