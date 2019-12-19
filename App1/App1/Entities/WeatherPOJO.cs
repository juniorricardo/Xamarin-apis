using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Entities
{
    public class WeatherPOJO
    {
        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
}
