using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Entities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteNewsList : ContentPage
    {
        public FavoriteNewsList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getFavorites();
        }

        public void getFavorites()
        {
            var favList = JsonConvert.DeserializeObject<List<Articles>>(CacheMemory.MyCache.Get("favorites").ToString());
            this.favoritesList.ItemsSource = favList;
        }

    }
}