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
            getClima(myService);

        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    getClima(myService);
        //}

        
        public string GenerateRequestUriCity(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q=Pilar";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private async void getClima(object sender)
        {
            WeatherPOJO weatherData;
            weatherData = await myService.GetWeatherDataCity(GenerateRequestUriCity(ConnectionApiOpenWeather.OpenWeatherMapEndpointCity));
            ciudadlbl.Text = $"{weatherData.Title}";
            temperaturalbl.Text = $"{weatherData.Main.Temperature.ToString()}";
        }

        private async void Button_Clicked(object sender, EventArgs e)
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

        private async Task getClimaCordAsync(object sender, double enLatitud, double enLongitud)
        {
            WeatherObjectJson weatherCord;
            weatherCord = await myService.GetWeatherDataCord(GenerateRequestUriCord(ConnectionApiOpenWeather.OpenWeatherMapEndpointCord, enLatitud, enLatitud));
            var lista = weatherCord.list.FirstOrDefault();
            climaUbicacionlbl.Text = $"{lista.name} - {lista.sys.country} ; {lista.main.temp}";
        }
        public string GenerateRequestUriCord(string endpoint, double enLatitud, double enLongitud)
        {
            /*  api.openweathermap.org/data/2.5/find ?lat=55.5 &lon=37.5&cnt=10
             *  openweathermap.org/data/2.5/find?lat=55.5&lon=37.5&cnt=10&appid=b6907d289e10d714a6e88b30761fae22
             */
            string requestUri = endpoint;
            requestUri += $"?lat={enLatitud}";
            requestUri += $"&lon={enLongitud}";
            requestUri += "&cnt=10";
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
