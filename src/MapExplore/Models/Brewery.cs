using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace MapExplore.Models
{
    public class Brewery
    {
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Name { get; set; }

        public void GetBreweries()
        {
            var client = new RestClient("http://api.brewerydb.com/v2");
            var request = new RestRequest("/location/d25euF/?key=65c0242a26aa3edd867b8ea8edaf7236", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var brewery = JsonConvert.DeserializeObject<JObject>(jsonResponse["data[name]"].ToString());
            Debug.WriteLine(brewery);
            

        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
