using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Entities;
using AppDemo.Service;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsViewPage : ContentPage
    {
        private NewsPOJO articulos;
        private NewsService myServiceNews;
        public static IMemoryCache cache;
        public NewsViewPage()
        {
            InitializeComponent();

            articulos = new NewsPOJO();

            myServiceNews = new NewsService();

            cache = new MemoryCache(new MemoryCacheOptions() { });

            listNewsView.ItemSelected += NewCell_ItemSelected;

        }

        private void NewCell_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var newsSelected = e.SelectedItem as Articles;
            Navigation.PushAsync(new DetailNewPage(newsSelected));
            //((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            findNews(myServiceNews);
        }

        private async void findNews(object sender)
        {
            articulos = await myServiceNews.getNews(GenerateRequestUri(ConnectionApiNews.NewsApiEndPoint));
            var descrip = articulos.articles.FirstOrDefault().description;
            var autor = articulos.articles.FirstOrDefault().author;
            this.listNewsView.ItemsSource = articulos.articles;
        }

        public string GenerateRequestUri(string enEndPoint)
        {
            /** newsapi.org/v2/top-headlines
             * ?sources=bbc-news
             * &apikey=b15a5c3ce62b49c18c79831f1467aa64
             */
            string requestUri = enEndPoint;
            requestUri += $"?sources=bbc-news&apikey={ConnectionApiNews.NewsApiKey}"; ;
            return requestUri;
        }

        private void addFavorites_Clicked(object sender, EventArgs e)
        {
            cache.Set("algo", "Estamos mal");
            DisplayAlert("Mensaje", $"Detalle: {cache.Get("algo")}", "Ok");
        }
    }
}