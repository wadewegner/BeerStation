using System.Net.Http;
using BeerStation.Services;
using BeerStation.Services.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerStation.FunctionalTests
{
    [TestFixture]
    public class Tests
    {
        private readonly string _clientId = "64dbf6d725f15a0baa1485a1e58208ce";
        private readonly string _clientSecret = "470d5b59cd063eafe820696b7e4a44c5";

        [Test]
        public async void BeerSearch_IsNotNull()
        {
            var untappdClient = new UntappdClient(_clientId, _clientSecret);
            var beers = await untappdClient.BeerSearch("stone");

            Assert.IsNotNull(beers);
            Assert.AreNotEqual(0, beers.Count);
        }

        [Test]
        public async void BrewerySearch_IsNotNull()
        {
            var untappdClient = new UntappdClient(_clientId, _clientSecret);
            var breweries = await untappdClient.BrewerySearch("stone");

            Assert.IsNotNull(breweries);
            Assert.IsNotNull(breweries.Count);
        }

        [Test]
        public async void BeerInfo_IsNotNull()
        {
            var untappdClient = new UntappdClient(_clientId, _clientSecret);
            var beer = await untappdClient.BeerInfo("3839");

            Assert.IsNotNull(beer);
        }
    }
}
