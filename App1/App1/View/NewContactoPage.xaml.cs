using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Entities;

namespace AppDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewContactoPage : ContentPage
    {
        public NewContactoPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Contacto nuevoContacto = new Contacto()
            {
                Nombre = nombreEntry.Text,
                Apellido = apellidoEntry.Text,
                Email = emailEntry.Text,
                Telefono = telefonoEntry.Text
            };

            using (var conn = new SQLite.SQLiteConnection(App.RUTA_DB))
            {
                conn.CreateTable<Contacto>();
                conn.Insert(nuevoContacto);
            }
            await Navigation.PopModalAsync();
        }
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}