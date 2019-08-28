using System;
using System.Collections.Generic;
using Xamarin.Forms;

using ProyectoFinal.Modelos;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using ProyectoFinal.Datos;

namespace ProyectoFinal
{
    public partial class DetallePaises
    {
        public DetallePaises()
        {
            InitializeComponent();
        }

        public DatosPaises Modelo { get; set; }
        
        protected override async void OnAppearing()
        {
            BindingContext = Modelo;

            base.OnAppearing();

            //
            //var posicion = new Position(8.933459, -83.077056);

            try
            {
                //var actual = await Geolocation.GetLocationAsync();

                //if (actual != null)
                //{
                  //  posicion = new Position(actual.Latitude, actual.Longitude);
                //}
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }


            //Mapa.Pins.Add(new Pin { Label = "Estoy aqui", Position = posicion });

            //var mapSpan = MapSpan.FromCenterAndRadius(posicion, Distance.FromMiles(0.5));

            //Mapa.MoveToRegion(mapSpan);
        }
    }
}