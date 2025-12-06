using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Entregas = new HashSet<Entrega>();
            Usuarios = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public bool FlActivo { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
