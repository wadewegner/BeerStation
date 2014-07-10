using System.Collections.Generic;

namespace BeerStation.Services.Models
{
    public class RootObject
    {
        public Meta meta { get; set; }
        public List<object> notifications { get; set; }
        public Response response { get; set; }
    }
}
