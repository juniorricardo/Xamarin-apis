using AppDemo.Service;
using AppDemo.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AppDemo.View
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        WeatherService myService;
        double lat;
        double lon;

        public MainPage()
        {
            InitializeComponent();
            myService = new WeatherService();
            getClima();

        }
        public string GenerateRequestUriCity(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q=Pilar";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private async void getClima()
        {
            WeatherPOJO weatherData;
            weatherData = await myService.GetWeatherDataCity(GenerateRequestUriCity(ConnectionApiOpenWeather.OpenWeatherMapEndpoint));
            ciudadlbl.Text = $"{weatherData.Title}";
            temperaturalbl.Text = $"{weatherData.Main.Temperature.ToString()}";
        }
        

        private async Task getClimaCordAsync(object sender, double enLatitud, double enLongitud)
        {
            WeatherCord weatherCord;
            weatherCord = await myService.GetWeatherDataCord(GenerateRequestUriCord(ConnectionApiOpenWeather.OpenWeatherMapEndpoint, enLatitud, enLatitud));
            
            this.Uciudadlbl.Text= weatherCord.name;
            this.Upaislbl.Text = weatherCord.sys.country;
            this.Uclimalbl.Text = weatherCord.weather.FirstOrDefault().main;
            this.Udescripcionlbl.Text = weatherCord.weather.FirstOrDefault().description;
            this.Utemperaturalbl.Text = weatherCord.main.temp.ToString();
            //climaUbicacionlbl.Text = $"{ciudad} - {pais} ; Temperatura: {temperatura}; Clima: {clima}, {descripcionClima}";
        }
        public string GenerateRequestUriCord(string endpoint, double enLatitud, double enLongitud)
        {
            /**  
             *  api.openweathermap.org/data/2.5/weather
             *  ?lat=-45.57524
             *  &lon=-72.06619
             *  &units=metric&lang=es
             *  &appid=1a663d2e10908df23d8e0622c0fdedf9
             */
            string requestUri = endpoint;
            requestUri += $"?lat={enLatitud}";
            requestUri += $"&lon={enLongitud}";
            requestUri += "&units=metric&lang=es";
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    //climaUbicacionlbl.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                    lat = location.Latitude;
                    lon = location.Longitude;
                    await getClimaCordAsync(myService, lat, lon);
                }
            }
            #region Catchs
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            #endregion
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
        }
    }
}
