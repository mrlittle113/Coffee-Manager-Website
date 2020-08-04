using System;

namespace CoffeeShops.Models.Json
{
    public class Assign
    {
        public int id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> shift_id { get; set; }
        public Nullable<int> week_id { get; set; }

        //
        private Employee employee { get; set; }
        private Shift shift { get; set; }
        //
        public static Assign JsonConvert(assign_shifts entity)
        {
            return new Assign()
            {
                id=entity.id,
                employee_id=entity.employee_id,
                shift_id = entity.shift_id,
                week_id =entity.week_id
            };
        }
    }
}