using AppDemo.Entities;
using AppDemo.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace AppDemo
{
    public partial class App : Application
    {
       public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static string RUTA_DB;
        public App(string ruta_db)
        {
            InitializeComponent();

            //CacheMemory.MyCache.Set("favorites", new List<Articles>());

            MainPage = new MasterPage();

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
