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
    public partial class DetailContactoPage : ContentPage
    {
        public DetailContactoPage()
        {
            InitializeComponent();
        }

        public Contacto Contacto { get; set; }
        public DetailContactoPage(Contacto contacto)
        {
            InitializeComponent();

            Contacto = contacto;

            nombreLabel.Text = $"{Contacto.Nombre} {Contacto.Apellido}";
            correoLabel.Text = Contacto.Email;
            telefonoLabel.Text = Contacto.Telefono;

        }
    }
}