using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Upstart13.Weather.API.Models;

namespace Upstart13.Weather.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {

        private readonly ILogger<ForecastController> _logger;

        public ForecastController(ILogger<ForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets Next 7 days weather information about an specific US Address
        /// </summary>
        /// <param name="address">An US Valid Address</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Forecast/{address}")]
        public async Task<IActionResult> GetAsync(string address)
        {

            string urlGetCoordinates = $"https://geocoding.geo.census.gov/geocoder/locations/onelineaddress?address={address}&benchmark=Public_AR_Current&format=json";
            
            var _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync(urlGetCoordinates);
            var content = await response.Content.ReadAsStringAsync();

            GeocodingResult GCResult = JsonConvert.DeserializeObject<GeocodingResult>(content);

            if (GCResult != null && GCResult.result.addressMatches.Count > 0)
            {

                string x = GCResult.result.addressMatches[0].coordinates.x.ToString();
                string y = GCResult.result.addressMatches[0].coordinates.y.ToString();

                string urlGetGrid = $"https://api.weather.gov/points/{y},{x}";

                _httpClient.DefaultRequestHeaders.Add("User-Agent", "(upstart13.com, info@upstart13.com)");
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/geo+json");

                response = await _httpClient.GetAsync(urlGetGrid);
                content = await response.Content.ReadAsStringAsync();

                GridResult GResult = JsonConvert.DeserializeObject<GridResult>(content);
                if (GResult != null)
                {
                    string gridId = GResult.properties.gridId.ToString();
                    string gridX = GResult.properties.gridX.ToString();
                    string gridY = GResult.properties.gridY.ToString();

                    string urlGetWeather = $"https://api.weather.gov/gridpoints/{gridId}/{gridX},{gridY}/forecast";

                    response = await _httpClient.GetAsync(urlGetWeather);
                    content = await response.Content.ReadAsStringAsync();

                    ForecastResult FResult = JsonConvert.DeserializeObject<ForecastResult>(content);
                    if (FResult != null && FResult.properties.periods.Count > 0)
                    {
                        return Ok(content);
                    } else {
                        return NotFound("Forecast not found");
                    }
                } else {
                    return NotFound("Grid not found");
                }
            } else {
                return NotFound("Address not found");
            }
        }
    }
}
