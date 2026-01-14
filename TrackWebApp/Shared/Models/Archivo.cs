using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class Archivo
    {
        public int Id { get; set; }
        public int IdEntrega { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string TipoMime { get; set; } = null!;
        public long TamanoBytes { get; set; }
        public byte[] Contenido { get; set; } = null!;
        public DateTime FechaAlta { get; set; }

        public virtual Entrega IdEntregaNavigation { get; set; } = null!;
    }
}
