using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppDemo.Entities;
using Newtonsoft.Json;

namespace AppDemo.Service
{
    public class WeatherService
    {
        HttpClient _client;

        public WeatherService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherPOJO> GetWeatherData(string query)
        {
            WeatherPOJO weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherPOJO>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return weatherData;
        }
    }
}
