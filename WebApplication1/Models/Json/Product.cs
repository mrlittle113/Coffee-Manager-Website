using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShops.Models.Json
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string formular { get; set; }
        public int price { get; set; }


        public static Product JsonConvert(products entity)
        {
            return new Product()
            {
                id = entity.id,
                name = entity.name,
                formular = entity.formular,
                price = entity.price.Value
            };
        }
    }
}