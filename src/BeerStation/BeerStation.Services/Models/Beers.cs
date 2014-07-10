using System.Collections.Generic;

namespace BeerStation.Services.Models
{
    public class Beers
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }
}