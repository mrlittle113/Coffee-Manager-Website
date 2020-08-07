using System;
using System.Collections.Generic;

namespace CoffeeShops.Models.Json
{
    public class Week
    {
        public int id { get; set; }
        public Nullable<int> week_number { get; set; }
        public Nullable<int> store_id { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        //
        private List<Assign> assigns { get; set; }
        //
        public static Week JsonConvert(shifts_week entity)
        {
            List<Assign> list = new List<Assign>();
            foreach (assign_shifts assign in entity.assign_shifts)
            {
                list.Add(Assign.JsonConvert(assign));
            }
            return new Week()
            {
                id = entity.id,
                week_number = entity.week_number,
                store_id = entity.store_id,
                start_date = entity.start_date,
                assigns = list
            };
        }
    }
}