namespace BeerStation.Services.Models
{
    public class Response
    {
        public string message { get; set; }
        public bool brewery_id { get; set; }
        public int type_id { get; set; }
        public int search_version { get; set; }
        public int found { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string term { get; set; }
        public string parsed_term { get; set; }
        public Beers beers { get; set; }
        public Homebrew homebrew { get; set; }
        public Breweries breweries { get; set; }
        public string search_type { get; set; }
        public string sort { get; set; }
        public string key { get; set; }
        public Brewery brewery { get; set; }
        public Beer beer { get; set; }
    }
}