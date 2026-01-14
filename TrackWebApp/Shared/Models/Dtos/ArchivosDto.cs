using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class ArchivosDto
    {
        public int Id { get; set; }
        public int IdEntrega { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string TipoMime { get; set; } = null!;
        public long TamanoBytes { get; set; }
        public byte[]? Contenido { get; set; }
        public DateTime? FechaAlta { get; set; }

        public string? ContenidoBase64 { get; set; }

    }
}
