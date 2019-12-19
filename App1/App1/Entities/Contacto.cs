using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Entities
{
    public class Contacto
    {

        private string nombre;
        private string apellido;
        private string email;
        private string telefono;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    }
}
