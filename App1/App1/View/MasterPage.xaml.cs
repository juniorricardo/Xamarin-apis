using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Service;
using AppDemo.Entities;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : Shell
    {
        WeatherService myService;
        public MasterPage()
        {
            InitializeComponent();

            myService = new WeatherService();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            getClima(myService);
        }
        public string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q=Pilar";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        async void getClima(object sender)
        {
            WeatherPOJO weatherData;
             weatherData = await myService.GetWeatherData(GenerateRequestUri(ConnectionApiOpenWeather.OpenWeatherMapEndpoint));
            ciudadLabel.Text = $"{weatherData.Title}";
            temperaturaLabel.Text = $"{weatherData.Main.Temperature.ToString()}";

        }
    }
}