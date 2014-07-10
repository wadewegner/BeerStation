using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeerStation.Services
{
    public class ServiceHttpClient
    {
        private readonly string _baseUri;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private HttpClient _httpClient;
        private readonly string _auth;


        public ServiceHttpClient(string clientId, string clientSecret, HttpClient httpClient)
        {
            _baseUri = "http://api.untappd.com/v4";
            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = httpClient;

            _auth = string.Format("?client_id={0}&client_secret={1}", _clientId, _clientSecret);

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> HttpGetAsync<T>(string methodName, string urlSuffix)
        {
            var url = string.Format("{0}/{1}{2}&{3}", _baseUri, methodName, _auth, urlSuffix);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            var responseMessage = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jToken = JToken.Parse(response);
                if (jToken.Type == JTokenType.Array)
                {
                    var jArray = JArray.Parse(response);

                    var r = JsonConvert.DeserializeObject<T>(jArray.ToString());
                    return r;
                }
                else
                {
                    var jObject = JObject.Parse(response);

                    var r = JsonConvert.DeserializeObject<T>(jObject.ToString());
                    return r;
                }
            }

            //TODO: better handle HTTP error response

            //var errorResponse = JsonConvert.DeserializeObject<dynamic>(response);
            //throw new Exception(errorResponse[0].errorCode, errorResponse[0].message);
            throw new Exception("Error with API");
        }
    }
}
