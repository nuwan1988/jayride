using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class Location
    {
        public string GetApiUrl(IConfiguration config, string ipAddress)
        {
            var key = config.GetSection("IpStack").GetSection("Key").Value;
            return "http://api.ipstack.com/" + ipAddress + "?access_key=" + key;
        }
    }
}
