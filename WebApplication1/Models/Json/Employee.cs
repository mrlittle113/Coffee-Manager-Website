using System;

namespace CoffeeShops.Models.Json
{
    public class Employee
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public Nullable<int> role { get; set; }
        public Nullable<int> salary_rate { get; set; }
        public Nullable<int> store_id { get; set; }
        public System.DateTime joined_date { get; set; }


        public static Employee JsonConvert(employees Entity)
        {
            Employee emp = new Employee
            {
                id = Entity.id,
                username = Entity.username,
                password = Entity.password,
                name = Entity.name,
                date_of_birth = Entity.date_of_birth,
                phone_number = Entity.phone_number,
                address = Entity.address,
                role = Entity.role
            };
            emp.salary_rate = emp.salary_rate;
            emp.store_id = Entity.store_id;
            emp.joined_date = Entity.joined_date;
            return emp;
        }
    }


}