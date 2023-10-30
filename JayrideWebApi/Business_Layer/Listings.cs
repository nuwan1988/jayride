using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess_Layer.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Linq;

namespace Business_Layer
{
    public class Listings
    {
        public string GetApiUrl(IConfiguration config)
        {
            var key = config.GetSection("JayRideApi").Value;
            return key;
        }

        public List<ListingsData> JayRideApiData(string content, int passengers)
        {
            try
            {
                JayrideClass list = JsonConvert.DeserializeObject<JayrideClass>(content);
                List<ListingsData> filteredItems = list.Listings.Where(x => x.VehicleType.MaxPassengers >= passengers).ToList();

                foreach (var items in filteredItems)
                {
                    items.TotalPrice = items.PricePerPassenger * passengers;
                }

                filteredItems = filteredItems.OrderBy(x => x.TotalPrice).ToList();
                return filteredItems;
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
