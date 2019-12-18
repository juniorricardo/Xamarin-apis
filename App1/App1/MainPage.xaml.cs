using App1.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        List<Contacto> listaContactos;
        public MainPage()
        {
            InitializeComponent();
            listaContactos = new List<Contacto>();
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

        private void Buton_Enviar(object sender, EventArgs args)
        {
            //string mensajeUsuario = mensajeEntry.Text;
            //DisplayAlert("Error!", $"Hola {mensajeUsuario}", "Aceptar");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //string mensaje = usuarioEntry.Text.Equals("junior")
            //    ? $"Login correcto {usuarioEntry.Text}"
            //    : $"Error al iniciar: {usuarioEntry.Text}, no existe";
            //DisplayAlert("Holaa!", mensaje, "Aceptar");
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevoContactoPage());
        }
    }
}
