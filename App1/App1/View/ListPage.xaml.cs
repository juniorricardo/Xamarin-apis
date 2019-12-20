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
    public partial class ListPage : ContentPage
    {
        List<Contacto> listaContactos;
        public ListPage()
        {
            InitializeComponent();

            listaContactos = new List<Contacto>();

            contactosListView.ItemSelected += ContactosListView_ItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var conn = new SQLite.SQLiteConnection(App.RUTA_DB))
            {
                conn.CreateTable<Contacto>();
                listaContactos = conn.Table<Contacto>().ToList();
            }
            contactosListView.ItemsSource = listaContactos;

        }

        private void ContactosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contactoSeleccionado = e.SelectedItem as Contacto;
            Navigation.PushAsync(new DetailContactoPage(contactoSeleccionado));
            contactosListView.SelectedItem = null;
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewContactoPage()));
        }
    }
}