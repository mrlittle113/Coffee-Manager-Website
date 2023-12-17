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
        public Employee employee { get; set; }
        public Shift shift { get; set; }
        //
        public static Assign JsonConvert(assign_shifts entity)
        {
            return new Assign()
            {
                id = entity.id,
                employee_id = entity.employee_id,
                shift_id = entity.shift_id,
                week_id = entity.week_id,
                employee = Employee.JsonConvert(entity.employees),
                shift = Shift.JsonConvert(entity.shifts)
            };
        }
    }
}