using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class UsuarioDto
    {
        public int Id { get; set; }
        public Guid IdEmpresa { get; set; }
        public string Nombre { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool FlActivo { get; set; }
        public string AndroidId { get; set; } = null!;
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public DateTime? FechaHoraGps { get; set; }
     
    }
}
