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

        //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ItemsPage)));
            //MenuPages.Add((int)MenuItemType.Lista, (NavigationPage)Detail);
            
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
