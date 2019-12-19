using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppDemo.Models;
using AppDemo.Service;
using AppDemo.Entities;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        WeatherService myService;
        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Lista, Title="Lista" },
                new HomeMenuItem {Id = MenuItemType.Noticias, Title="Noticias" },
                new HomeMenuItem {Id = MenuItemType.Ajustes, Title="Ajustes" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

            myService = new WeatherService();
            getClima(myService);
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q=Pilar";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private async void getClima(object sender)
        {
            WeatherPOJO weatherData = await myService.GetWeatherData(GenerateRequestUri(ConnectionApiOpenWeather.OpenWeatherMapEndpoint));
            lblClima.Text = $"{weatherData.Title} {weatherData.Main.Temperature.ToString()}";
        }
    }
}