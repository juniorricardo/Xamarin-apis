using App1.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoContactoPage : ContentPage
    {
        public NuevoContactoPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
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


        }
    }
}