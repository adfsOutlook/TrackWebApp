using System;
using System.Collections.Generic;

namespace Project.Shared.Models
{
    public partial class EntregaDto
    {
        public int Id { get; set; }
        public Guid IdEmpresa { get; set; }
        public int IdUsuarioAsignado { get; set; }
        public int IdAgendaUsuario { get; set; }
        public int? IdRutaUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdSisResponsableIngreso { get; set; }
        public int IdSisTramite { get; set; }
        public int SisTramite { get; set; }
        public string? Origen { get; set; }
        public DateTime FechaHoraEntrega { get; set; }
        public string LugarEntrega { get; set; } = null!;
        public int IdSisInstitucion { get; set; }
        public string? SectorEntrega { get; set; }
        public string? DireccionEntrega { get; set; }
        public string? LocalidadEntrega { get; set; }
        public string? ProvinciaEntrega { get; set; }
        public string? TelefonoEntrega { get; set; }
        public string? Medico { get; set; }
        public int? IdSisMedico { get; set; }
        public string? Cliente { get; set; }
        public int? IdSisCliente { get; set; }
        public string? Material { get; set; }
        public string? Observaciones { get; set; }
        public bool EntregaFlEntregado { get; set; }
        public DateTime? EntregaFechaHora { get; set; }
        public string? EntregaObservaciones { get; set; }
        public bool EntregaFlProblemas { get; set; }
        public bool EntregaFlTarde { get; set; }
        public bool EntregaFlNoEntregado { get; set; }
        public string? EntregaDocumentos { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }


    }
}
