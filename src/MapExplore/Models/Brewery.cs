using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace MapExplore.Models
{
    public class Brewery
    {
        [Key]
        public int BreweryId { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Name { get; set; }

        private MapExploreDbContext db = new MapExploreDbContext();
        public static List<Brewery> GetBreweries(string zip)
        {
            var client = new RestClient("http://api.brewerydb.com/v2");
            var request = new RestRequest("/locations/?key=" + EnvironmentVariables.BreweryKey + "&postalCode=" + zip , Method.GET);
            Debug.WriteLine(request +"++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            
            var response = new RestResponse();
                Task.Run(async () =>
                {
                    response = await GetResponseContentAsync(client, request) as RestResponse;
                }).Wait();
            if (response.ContentLength != 36 )
            {
                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
                JObject[] brewery = JsonConvert.DeserializeObject<JObject[]>(jsonResponse["data"].ToString());

                List<Brewery> myList = new List<Brewery>() { };
                foreach (var guy in brewery)
                {
                    Brewery newBrewery = new Brewery();
                    newBrewery.Name = guy["name"].ToString();
                    newBrewery.Lat = guy["latitude"].ToString();
                    newBrewery.Long = guy["longitude"].ToString();
                    myList.Add(newBrewery);

                }
                Debug.WriteLine(myList);
                return myList;
            }
            else
            {
                List<Brewery> myList = new List<Brewery>() { };
                return myList;
              
            }
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
