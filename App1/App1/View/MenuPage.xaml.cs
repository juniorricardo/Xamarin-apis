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
        List<HomeMenuItem> MenuPages { get; set; }
        WeatherService myService;
        public MenuPage()
        {
            InitializeComponent();
            MenuPages = new List<HomeMenuItem>();

            var page1 = new HomeMenuItem { Id = MenuItemType.Lista, Title = "Lista", TargetType = typeof(ListPage) };
            var page2 = new HomeMenuItem { Id = MenuItemType.Noticias, Title = "Noticias",TargetType = typeof(NewsPage)};

            MenuPages.Add(page1);
            MenuPages.Add(page2);

            ListViewMenu.ItemsSource = MenuPages;

            //ListViewMenu.SelectedItem = menuItems[0];
            //ListViewMenu.ItemSelected += async (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //        return;

            //    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //    await RootPage.NavigateFromMenu(id);
            //};


            ListViewMenu.ItemSelected += OnItemSelected;
            myService = new WeatherService();
            getClima(myService);
        }

        #region Metodos-Clima
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
        #endregion

        //public async Task NavigateFromMenu(int id)
        //{
        //    if (!MenuPages.ContainsKey(id))
        //    {
        //        switch (id)
        //        {
        //            case (int)MenuItemType.Lista:
        //                MenuPages.Add(id, new NavigationPage(new ListPage()));
        //                break;
        //            case (int)MenuItemType.Noticias:
        //                MenuPages.Add(id, new NavigationPage(new NewsPage()));
        //                break;
        //        }
        //    }

        //    var newPage = MenuPages[id];

        //    if (newPage != null && Detail != newPage)
        //    {
        //        Detail = newPage;

        //        if (Device.RuntimePlatform == Device.Android)
        //            await Task.Delay(100);

        //        IsPresented = false;
        //    }
        //}
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomeMenuItem;
            if (item != null)
            {
                await Navigation.PushModalAsync((Page)Activator.CreateInstance(item.TargetType));
                
            }
        }
    }
}