using System;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace ProyectoFinal.Modelos
{
    [Table("all")]
    public class dPaises

    {
        [JsonProperty(PropertyName = "name")]
        [Column(nameof(Nombre)), NotNull]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")]
        [Column(nameof(AlphaCode)), NotNull]
        public string AlphaCode { get; set; }

        Property(PropertyName = "capital")]
        [Column(nameof(Capital)), NotNull]
        public string Capital { get; set; }
        
    }
}

