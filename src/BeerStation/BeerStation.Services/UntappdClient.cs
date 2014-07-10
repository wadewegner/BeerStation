using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BeerStation.Services.Models;

namespace BeerStation.Services
{
    public class UntappdClient
    {
        private HttpClient _httpClient;
        private string _clientSecret;
        private string _clientId;
        private ServiceHttpClient _serviceHttpClient;

        public UntappdClient(string clientId, string clientSecret)
            : this(clientId, clientSecret, new HttpClient())
        {

        }

        public UntappdClient(string clientId, string clientSecret, HttpClient httpClient)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = httpClient;

            _serviceHttpClient = new ServiceHttpClient(_clientId, _clientSecret, _httpClient);
        }

        public async Task<List<Beer>> BeerSearch(string query)
        {
            var urlSuffix = string.Format("q={0}", query);
            var result = await _serviceHttpClient.HttpGetAsync<RootObject>("search/beer", urlSuffix);
            var beers = new List<Beer>();

            foreach (var item in result.response.beers.items)
            {
                beers.Add(item.beer);
            }
            
            return beers;
        }

        public async Task<List<Brewery>> BrewerySearch(string query)
        {
            var urlSuffix = string.Format("q={0}", query);
            var result = await _serviceHttpClient.HttpGetAsync<RootObject>("search/brewery", urlSuffix);

            var breweries = new List<Brewery>();

            foreach (var item in result.response.brewery.items)
            {
                breweries.Add(item.brewery);
            }

            return breweries;
        }

        public async Task<Beer> BeerInfo(string beerId)
        {
            var methodName = string.Format("beer/info/{0}", beerId);
            var result = await _serviceHttpClient.HttpGetAsync<RootObject>(methodName, "compact=true");
            var beer = result.response.beer;
            
            return beer;
        }
    }

}
