using System;
using System.Collections.Generic;

namespace Project.Server.Models
{
    public partial class Localizacione
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public DateTime? FechaHoraGps { get; set; }
        public int? IdEntrega { get; set; }
        public string? Distancia { get; set; }
        public string? Tiempo { get; set; }
        public string? HoraLlegada { get; set; }

        public virtual Entrega? IdEntregaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
