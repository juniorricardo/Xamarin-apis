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

        //[JsonProperty("weather")]
        //public Weather Weather { get; set; }

        //[JsonProperty("sys")]
        //public Sys Sys { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
    //public class Weather
    //{
    //    [JsonProperty("main")]
    //    public string main { get; set; }

    //    [JsonProperty("description")]
    //    public string description { get; set; }

    //    [JsonProperty("icon")]
    //    public string icon { get; set; }
    //}
    //public class Sys
    //{
    //    [JsonProperty("country")]
    //    public string country { get; set; }
    //}
}