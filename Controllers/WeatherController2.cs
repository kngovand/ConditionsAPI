using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConditionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WeatherController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet("index")]
        public string Index()
        {
            return "Hello from WeatherController";
        }

        [HttpGet("weatherforecast")]
        public async Task<string> GetApiResponse()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=39.5994&longitude=-105.9872&hourly=temperature_2m&forecast_days=3");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }




    }
}