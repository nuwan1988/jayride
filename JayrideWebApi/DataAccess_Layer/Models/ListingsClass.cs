using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess_Layer.Models
{
    public class JayrideClass
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<ListingsData> Listings { get; set; }        
    }

    public class ListingsData
    {
        public string Name { get; set; }
        public decimal PricePerPassenger { get; set; }
        public VehicleType VehicleType { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class VehicleType
    {
        public string Name { get; set; }
        public int MaxPassengers { get; set; }
    }
}
