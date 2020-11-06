using Newtonsoft.Json.Linq;
using ParkingApp.Interfaces;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingApp.Services
{
    public class GeocodingService : IGeocodingService
    {

       public async Task<ParkingSpot> AttachLatAndLong(ParkingSpot parkingSpot)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={parkingSpot.Address}+{parkingSpot.City}+{parkingSpot.State}+&key={APIKeys.GOOGLE_API_KEY}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(jsonResult);
            parkingSpot.Latitude = (double)jObject["results"][0]["geometry"]["location"]["lat"];
            parkingSpot.Longitude = (double)jObject["results"][0]["geometry"]["location"]["lng"];

            return parkingSpot;
        }
    }

    
}
