namespace CoffeeShops.Models.Json
{
    public class Shift
    {
        public int id { get; set; }
        public string shift_time { get; set; }

        public static Shift JsonConvert(shifts entity)
        {

            return new Shift()
            {
                id = entity.id,
                shift_time = entity.shift_time
            };

        }
    }

}