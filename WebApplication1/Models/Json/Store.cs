using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShops.Models.Json
{
    public class Store
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public Nullable<int> manager_id { get; set; }
        public System.DateTime created_date { get; set; }
        public ICollection<Employee> employees { get; set; }
        public ICollection<invoices> invoices { get; set; }
        public ICollection<reports> reports { get; set; }
        public ICollection<warehouses> warehouses { get; set; }

        public static Store JsonConvert(stores Entity)
        {
            Store store = new Store
            {
                id = Entity.id,
                name = Entity.name,
                address = Entity.name,
                phone_number = Entity.phone_number,
                email = Entity.email,
                manager_id = Entity.manager_id
            };
            foreach (employees emp_ent in Entity.employees.ToList())
            {
                Employee emp = Employee.JsonConvert(emp_ent);
                store.employees.Add(emp);
            }
            //tobe continue



            return store;
        }
    }
}