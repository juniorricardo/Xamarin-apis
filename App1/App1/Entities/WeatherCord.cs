using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Entities
{
    public class WeatherCord
    {
        [JsonProperty("coord")]
        public Coord coord { get; set; }

        [JsonProperty("weather")]
        public List<Weather> weather { get; set; }

        //          estación meteorológica
        [JsonProperty("base")]
        public string weatherStation { get; set; }

        [JsonProperty("main")]
        public MainCord main { get; set; }

        [JsonProperty("visibility")]
        public int visibility { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        //      Time of data calculation, unix, UTC
        [JsonProperty("dt")]
        public int dt { get; set; }

        [JsonProperty("sys")]
        public Sys sys { get; set; }

        //      Shift in seconds from UTC       
        [JsonProperty("timezone")]
        public int timezone { get; set; }

        //      City ID
        [JsonProperty("id")]
        public int id { get; set; }

        //      City name
        [JsonProperty("name")]
        public string name { get; set; }

        //      Internal parameter
        [JsonProperty("cod")]
        public int cod { get; set; }
    }
     public class Coord
    {
        /**     .lon City geo location, longitude
                .lat City geo location, latitude        */
        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }
    }
    public class Weather // (more info Weather condition codes)
    {
        /**     .id Weather condition id
                .main Group of weather parameters (Rain, Snow, Extreme etc.)
                .description Weather condition within the group
                .icon Weather icon id           */
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }
        //      Weather condition within the group
        [JsonProperty("description")]
        public string description { get; set; }

        //      Weather icon id
        [JsonProperty("icon")]
        public string icon { get; set; }
    }
    public class MainCord
    {
        /**     .temp Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
                .temp_min Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
                .temp_max Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
                .pressure Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
                .humidity Humidity, %        */

        [JsonProperty("temp")]
        public double temp { get; set; }

        [JsonProperty("temp_min")]
        public double temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double temp_max { get; set; }

        [JsonProperty("pressure")]
        public int pressure { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }
    }
    public class Wind
    {
        /**     .speed Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
                .deg Wind direction, degrees (meteorological)           */
        [JsonProperty("speed")]
        public double speed { get; set; }

        [JsonProperty("deg")]
        public int deg { get; set; }
    }

    public class Clouds
    {
        /**     .all Cloudiness, %        */
        [JsonProperty("all")]
        public int all { get; set; }
    }

    public class Sys
    {
        /**     .type Internal parameter
                .id Internal parameter
                .message Internal parameter
                .country Country code (GB, JP etc.)
                .sunrise Sunrise time, unix, UTC
                .sunset Sunset time, unix, UTC */
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("sunrise")]
        public int sunrise { get; set; }

        [JsonProperty("sunset")]
        public int sunset { get; set; }
    }

}