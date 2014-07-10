using System.Collections.Generic;

namespace BeerStation.Services.Models
{
    public class Brewery
    {
        public int brewery_id { get; set; }
        public string brewery_name { get; set; }
        public string brewery_label { get; set; }
        public string country_name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public int brewery_active { get; set; }
        public int beer_count { get; set; }
        public int count { get; set; }
        public List<Item> items { get; set; }
    }
}