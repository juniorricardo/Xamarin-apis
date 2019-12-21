using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using AppDemo.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Entities;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {

        public static List<NewsPOJO> listaNoticias = new List<NewsPOJO>();

        //NewsService myServiceNews;
        public NewsPage()
        {
            InitializeComponent();

            //myServiceNews = new NewsService();

        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    listaNoticias = myServiceNews.getNews();
        //    newsListView.ItemsSource = listaNoticias;
        //}

    }
}