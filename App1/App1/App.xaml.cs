using AppDemo.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDemo
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static string RUTA_DB;
        public App(string ruta_db)
        {
            InitializeComponent();

            var navPage = new NavigationPage(new ItemsPage()) { Title = "Home" };
            var mdp = new MasterDetailPage()
            {
                Master = new MenuPage(),
                Detail = navPage
            };
            MainPage = mdp;
            //MainPage = new NavigationPage(new MainPage());

            RUTA_DB = ruta_db;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
