using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Business_Layer;
using System;
using Newtonsoft.Json;
using System.Linq;
using DataAccess_Layer.Models;
using System.Collections.Generic;

namespace JayrideWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly Listings _listing;

        public ListingsController(IConfiguration iConfig)
        {
            _httpClient = new HttpClient();
            _configuration = iConfig;
            _listing = new Listings();
        }

        [HttpGet("/Listings")]
        public async Task<IActionResult> Listings(int passengers)
        {
            try
            {
                if (passengers <= 0) return BadRequest("Invalid Passenger Count !");

                string apiUrl = _listing.GetApiUrl(_configuration);
                HttpResponseMessage jayRideApiRespoance = await _httpClient.GetAsync(apiUrl);
                if (jayRideApiRespoance.IsSuccessStatusCode)
                {
                    string content = await jayRideApiRespoance.Content.ReadAsStringAsync();
                    List<ListingsData> list = _listing.JayRideApiData(content, passengers);
                    if(list.Count != 0)
                        return Ok(list);
                    else 
                        return BadRequest("No Listing Found !");
                }
                else
                {
                    return BadRequest("Data Not Found !");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
