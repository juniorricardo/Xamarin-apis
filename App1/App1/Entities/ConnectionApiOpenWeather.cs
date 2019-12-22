using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Entities
{
    public class ConnectionApiOpenWeather
    {
        // api.openweathermap.org/data/2.5/weather ?lat=-34.82886944428761 &lon=-58.23416430269482 &units=metric &lang=es &appid=1a663d2e10908df23d8e0622c0fdedf9
        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public static string OpenWeatherMapAPIKey = "1a663d2e10908df23d8e0622c0fdedf9";
    }
}
