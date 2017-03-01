﻿using System;
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

        public void GetBreweries()
        {
            var client = new RestClient("http://api.brewerydb.com/v2");
            var request = new RestRequest("/locations/?key=" + EnvironmentVariables.BreweryKey + "&postalCode=97204", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            JObject[] brewery = JsonConvert.DeserializeObject<JObject[]>(jsonResponse["data"].ToString());
           foreach(var guy in brewery)
            {
            Name = guy["name"].ToString();
            Lat = guy["latitude"].ToString();
            Long = guy["longitude"].ToString();
            Debug.WriteLine(guy["longitude"]);

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
