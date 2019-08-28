using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

// Deserializacion
using Newtonsoft.Json;
using ProyectoFinal.Modelos;
using ProyectoFinal.Datos;

namespace ProyectoFinal
{
    public partial class ListadoPaises
    {
        public SQLiteDb BaseDatos { get => DependencyService.Get<SQLiteDb>(); }

        public ObservableCollection<DatosPaises> Datos { get; set; } = new ObservableCollection<DatosPaises>();

        public Command AgregarCommand { get; set; }

        public Command RefrescarCommand { get; set; }

        public ListadoPaises()
        {
            AgregarCommand = new Command(() =>
            {

                Datos.Add(new DatosPaises { Nombre = "Nuevo Item" });

            });

            RefrescarCommand = new Command(async () => {

                await Task.Delay(1000);

                Refrescar();

                IsBusy = false;
                
            });

            BindingContext = this;

            InitializeComponent();

            listViewDatos.ItemTapped += ListViewDatos_ItemTapped;
        }

        private async void Refrescar()
        {
            Datos.Clear();

            IsBusy = true;

            try
            {
                if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                {
                    await DisplayAlert("Importante", "No hay internet!", "Cerrar");

                    CargarDesdeLocal();
                    return;
                }

                // WebService, con conexion
                using (var httpClient = new HttpClient())
                {

                    const string restAPI = "https://restcountries.eu/rest/v2/";

                    httpClient.BaseAddress = new Uri(restAPI);

                    // importante: usar el await
                    var respuesta = await httpClient.GetAsync("all");

                    string resultado = await respuesta.Content.ReadAsStringAsync();

                    // Deserializar a clases
                    var objetos = JsonConvert.DeserializeObject<DatosPaises[]>(resultado);

                    //Datos.Add(resultado);
                    Console.WriteLine(resultado);

                    await BaseDatos.DeleteAllAsync();

                    foreach (DatosPaises item in objetos)
                    {
                        Datos.Add(item);
                        await BaseDatos.InsertAsync(item);
                    }

                    Console.WriteLine((await BaseDatos.ListAsync()).Count);

                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                CargarDesdeLocal();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void CargarDesdeLocal()
        {
            // Cargar desde SQLite
            var locales = await BaseDatos.ListAsync();

            foreach (var item in locales)
            {
                Datos.Add(item);
            }
        }

        // async
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Refrescar();
        }

        // async
        private async void ListViewDatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var seleccion = (DatosPaises)e.Item;

            await Navigation.PushAsync(new DetallePaises() { Modelo = seleccion });
        }
    }
}
