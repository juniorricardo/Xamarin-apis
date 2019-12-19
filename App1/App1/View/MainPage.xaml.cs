using AppDemo.Entities;
using AppDemo.Service;
using AppDemo.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDemo.View
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {

        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Lista, (NavigationPage)Detail);
            
        }
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Lista:
                        MenuPages.Add(id, new NavigationPage(new ListPage()));
                        break;
                    case (int)MenuItemType.Noticias:
                        MenuPages.Add(id, new NavigationPage(new NewsPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }


        #region PorImplementar

        //private async Task Button_ClickedAsync(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace("Pilar"))
        //    {
        //        WeatherPOJO weatherData = await myService.GetWeatherData(GenerateRequestUri(ConnectionApiOpenWeather.OpenWeatherMapEndpoint));
        //        BindingContext = weatherData;
        //    }
        //} 

        #endregion

    }
}
