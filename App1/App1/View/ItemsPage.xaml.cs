using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDemo.Entities;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
        }

        private void Add_Registro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewContactoPage());
        }
    }
}