using App1.Clases;
using App1.Service;
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
        WeatherService myService;
        List<Contacto> listaContactos;
        public MainPage()
        {
            myService = new WeatherService();
            getClima(myService);

            InitializeComponent();
            listaContactos = new List<Contacto>();

            contactosListView.ItemSelected += ContactosListView_ItemSelected;
        }

        private void ContactosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contactoSeleccionado = e.SelectedItem as Contacto;
            Navigation.PushAsync(new DetalleContactoPages(contactoSeleccionado));
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

        
       
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q=Pilar";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private async void getClima(object sender)
        {
            WeatherPOJO weatherData = await myService.GetWeatherData(GenerateRequestUri(ConnectionApiOpenWeather.OpenWeatherMapEndpoint));
            lblTitulo.Text = weatherData.Title;
            lblTemperatura.Text = weatherData.Main.Temperature.ToString();
        }



        #region NoUsados

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace("Pilar"))
            {
                WeatherPOJO weatherData = await myService.GetWeatherData(GenerateRequestUri(ConnectionApiOpenWeather.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        private void Buton_Enviar(object sender, EventArgs args)
        {
            //string mensajeUsuario = mensajeEntry.Text;
            //DisplayAlert("Error!", $"Hola {mensajeUsuario}", "Aceptar");
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevoContactoPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
        #endregion

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
