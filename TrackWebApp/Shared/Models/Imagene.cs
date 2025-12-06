using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class Imagene
    {
        public int Id { get; set; }
        public int? IdEntrega { get; set; }
        public byte[]? Contenido { get; set; }
        public string? TipoMime { get; set; }
    }
}
