using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Entities
{
    public class WeatherObjectJson
    {

        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("cod")]
        public string cod { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("list")]
        public List<Lista> list { get; set; }
    }

    public class Lista
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("coord")]
        public Coord coord { get; set; }

        [JsonProperty("main")]
        public MainObj main { get; set; }

        [JsonProperty("dt")]
        public int dt { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("sys")]
        public Sys sys { get; set; }

        [JsonProperty("rain")]
        public object rain { get; set; }

        [JsonProperty("snow")]
        public object snow { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("weather")]
        public List<Weather> weather { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }
    }

    public class MainObj
    {
        [JsonProperty("temp")]
        public double temp { get; set; }

        [JsonProperty("pressure")]
        public int pressure { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("temp_min")]
        public double temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double temp_max { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double speed { get; set; }

        [JsonProperty("deg")]
        public int deg { get; set; }

        [JsonProperty("gust")]
        public int gust { get; set; }
    }

    public class Sys
    {
        [JsonProperty("country")]
        public string country { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int all { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }
    }
}


