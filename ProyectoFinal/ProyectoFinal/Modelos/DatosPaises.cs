using System;
using Newtonsoft.Json;
using SQLite;

using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace ProyectoFinal.Modelos
{
    [Table("all")]
    public class DatosPaises
    {          
        //[PrimaryKey, Column("id"), AutoIncrement]
        //public string id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Column(nameof(Nombre)), NotNull]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")]
        [Column(nameof(AlphaCode)), NotNull]
        public string AlphaCode { get; set; }

        [JsonProperty(PropertyName = "capital")]
        [Column(nameof(Capital)), NotNull]
        public string Capital { get; set; }
    }
}