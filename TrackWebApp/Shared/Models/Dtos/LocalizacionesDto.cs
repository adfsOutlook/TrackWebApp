using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class LocalizacionesDto
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public DateTime? FechaHoraGps { get; set; }
        public int? IdEntrega { get; set; }

        // Datos de Google
        public string? Distancia { get; set; }
        public string? Tiempo { get; set; }
        public string? HoraLlegada { get; set; }

    }
}
