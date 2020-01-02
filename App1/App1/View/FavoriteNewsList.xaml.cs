using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Entities;
using AppDemo.View;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteNewsList : ContentPage
    {
        List<Articles> newsList;
        public FavoriteNewsList()
        {
            InitializeComponent();
            newsList = new List<Articles>();
        }
    }
}