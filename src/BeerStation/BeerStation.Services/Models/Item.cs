namespace BeerStation.Services.Models
{
    public class Item
    {
        public int checkin_count { get; set; }
        public bool have_had { get; set; }
        public int your_count { get; set; }
        public Beer beer { get; set; }
        public Brewery brewery { get; set; }
    }
}