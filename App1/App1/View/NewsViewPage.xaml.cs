using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public NewsViewPage()
        {
            InitializeComponent();

            articulos = new NewsPOJO();

            myServiceNews = new NewsService();
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
    }
}