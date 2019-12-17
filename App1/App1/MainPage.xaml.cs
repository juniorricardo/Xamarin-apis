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
        public MainPage()
        {
            InitializeComponent();
        }

        private void Buton_Enviar(object sender, EventArgs args)
        {
            //string mensajeUsuario = mensajeEntry.Text;
            //DisplayAlert("Error!", $"Hola {mensajeUsuario}", "Aceptar");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string mensaje;
            if (usuarioEntry.Text.Equals("junior"))
                mensaje = $"Login correcto {usuarioEntry.Text}";
            else
                mensaje = $"Error al iniciar: {usuarioEntry.Text}, no existe";

            DisplayAlert("Holaa!", mensaje, "Aceptar");
        }
    }
}
