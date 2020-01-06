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
            cargarDatosUsuarios();
        }
        private void cargarDatosUsuarios()
        {
            ActInd.IsRunning = true;
            using (var conn = new SQLite.SQLiteConnection(App.RUTA_DB))
            {
                conn.CreateTable<Contacto>();
                listaContactos = conn.Table<Contacto>().ToList();
            }
            contactosListView.ItemsSource = listaContactos;
            ActInd.IsRunning = false;
        }

        private void ContactosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contactoSeleccionado = e.SelectedItem as Contacto;
            Navigation.PushAsync(new DetailContactoPage(contactoSeleccionado));
            //((ListView)sender).SelectedItem = null;
        }

        //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewContactoPage()));
        }
    }
}