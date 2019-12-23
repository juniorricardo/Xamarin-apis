using AppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNewPage : ContentPage
    {
        public DetailNewPage(Articles article)
        {
            InitializeComponent();

            BindingContext = article;
        }
    }
}