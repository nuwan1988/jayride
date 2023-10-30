using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IpStack;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Business_Layer;
using Microsoft.Extensions.Configuration;
using System;

namespace JayrideWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly Location _loc;

        public LocationController(IConfiguration iConfig)
        {
            _httpClient = new HttpClient();
            _configuration = iConfig;
            _loc = new Location();
        }

        [HttpGet("/Location")]
        public async Task<IActionResult> Location(string ipAddress)
        {
            try
            {
                string apiUrl = _loc.GetApiUrl(_configuration, ipAddress.Trim());

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic locationData = JObject.Parse(content);

                    string city = locationData.city;
                    return Ok(city);
                }
                else
                {
                    return BadRequest("Unable to retrieve location.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
