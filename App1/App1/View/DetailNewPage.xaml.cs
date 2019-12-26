using AppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNewPage : ContentPage
    {
        string uriNews;
        public DetailNewPage(Articles article)
        {
            InitializeComponent();

            uriNews = article.url;
            BindingContext = article;
        }
       
        public async void openBrowserNews(object sender, EventArgs e)
        {
           await Browser.OpenAsync(uriNews);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
    
}