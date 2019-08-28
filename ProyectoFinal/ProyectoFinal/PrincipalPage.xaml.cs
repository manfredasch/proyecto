using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ProyectoFinal
{
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();

            Title = "Proyecto";
            NavigationPage.SetBackButtonTitle(this, Title);
            NavigationPage.SetHasNavigationBar(this, false);

            if (Device.RuntimePlatform == Device.iOS)
            {
                botonComenzar.BackgroundColor = Color.DarkGray;
            }

            botonComenzar.Clicked += BotonComenzar_Clicked;
        }

        private async void BotonComenzar_Clicked(object sender, EventArgs e)
        {
            //
            await Navigation.PushAsync(new MainPage()
            {
                NombreUsuario = entryNombre.Text
            });
        }
    }
}
