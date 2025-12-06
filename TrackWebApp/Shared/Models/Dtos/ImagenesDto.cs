using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class ImagenesDto
    {
        public int Id { get; set; }
        public int? IdEntrega { get; set; }
        public byte[]? Contenido { get; set; }
        public string? TipoMime { get; set; }

        public string? ContenidoBase64 { get; set; }
    }
}
