using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class EmpresaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public bool FlActivo { get; set; }
    }
}
