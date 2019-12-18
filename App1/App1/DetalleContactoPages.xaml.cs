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
    public partial class DetalleContactoPages : ContentPage
    {
        public Contacto Contacto { get; set; }
        public DetalleContactoPages(Contacto contacto)
        {
            InitializeComponent();

            Contacto = contacto;

            nombreLabel.Text = $"{Contacto.Nombre} {Contacto.Apellido}";
            correoLabel.Text = Contacto.Email;
            telefonoLabel.Text = Contacto.Telefono;

        }
    }
}