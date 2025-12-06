using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Server;
using Project.Server.Models;
using Project.Shared.Models;
using Project.Shared.Models.Dtos;
using static Project.Client.Pages.Domain;
namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasController : ControllerBase
    {
        private readonly TrackContext _context;
        public EntregasController(TrackContext context)
        {
            _context = context;
        }

  
        #region ENTREGAS

        [HttpGet("EntregasDtoGetByIdUsuarioEntregado/{IdUsuario}/{Entregado}")]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> EntregasDtoGetByIdUsuarioEntregado(int IdUsuario, bool Entregado)
        {
            var adminsQueryable = _context.Entregas.AsQueryable();

            List<EntregaDto> entregasDtoList = null;
            try
            {
                var entregas = await adminsQueryable.ToListAsync();
                entregasDtoList = entregas.Select(e => new EntregaDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    IdEmpresa = e.IdEmpresa,
                    IdUsuarioAsignado = e.IdUsuarioAsignado,
                    IdAgendaUsuario = e.IdAgendaUsuario,
                    IdRutaUsuario = e.IdRutaUsuario,
                    FechaIngreso = e.FechaIngreso,
                    IdSisResponsableIngreso = e.IdSisResponsableIngreso,
                    IdSisTramite = e.IdSisTramite,
                    SisTramite = e.SisTramite,
                    Origen = e.Origen,
                    FechaHoraEntrega = e.FechaHoraEntrega,
                    LugarEntrega = e.LugarEntrega,
                    IdSisInstitucion = e.IdSisInstitucion,
                    SectorEntrega = e.SectorEntrega,
                    DireccionEntrega = e.DireccionEntrega,
                    LocalidadEntrega = e.LocalidadEntrega,
                    ProvinciaEntrega = e.ProvinciaEntrega,
                    TelefonoEntrega = e.TelefonoEntrega,
                    Medico = e.Medico,
                    IdSisMedico = e.IdSisMedico,
                    Cliente = e.Cliente,
                    IdSisCliente = e.IdSisCliente,
                    Material = e.Material,
                    Observaciones = e.Observaciones,
                    EntregaFlEntregado = e.EntregaFlEntregado,
                    EntregaFechaHora = e.EntregaFechaHora,
                    EntregaObservaciones = e.EntregaObservaciones,
                    EntregaFlProblemas = e.EntregaFlProblemas,
                    EntregaFlTarde = e.EntregaFlTarde,
                    EntregaFlNoEntregado = e.EntregaFlNoEntregado,
                    EntregaDocumentos = e.EntregaDocumentos,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud

                }).Where(x => x.IdUsuarioAsignado == IdUsuario).ToList();
            }
            catch (Exception ex)
            {

                return NotFound();

            }



            return entregasDtoList;
        }

        [HttpGet("EntregasDtoGetByIdEntrega/{IdEntrega}")]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> EntregasDtoGetByIdEntrega(int IdEntrega)
        {
            var adminsQueryable = _context.Entregas.AsQueryable();

            List<EntregaDto> entregasDtoList = null;
            try
            {
                var entregas = await adminsQueryable.ToListAsync();
                entregasDtoList = entregas.Select(e => new EntregaDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    IdEmpresa = e.IdEmpresa,
                    IdUsuarioAsignado = e.IdUsuarioAsignado,
                    IdAgendaUsuario = e.IdAgendaUsuario,
                    IdRutaUsuario = e.IdRutaUsuario,
                    FechaIngreso = e.FechaIngreso,
                    IdSisResponsableIngreso = e.IdSisResponsableIngreso,
                    IdSisTramite = e.IdSisTramite,
                    SisTramite = e.SisTramite,
                    Origen = e.Origen,
                    FechaHoraEntrega = e.FechaHoraEntrega,
                    LugarEntrega = e.LugarEntrega,
                    IdSisInstitucion = e.IdSisInstitucion,
                    SectorEntrega = e.SectorEntrega,
                    DireccionEntrega = e.DireccionEntrega,
                    LocalidadEntrega = e.LocalidadEntrega,
                    ProvinciaEntrega = e.ProvinciaEntrega,
                    TelefonoEntrega = e.TelefonoEntrega,
                    Medico = e.Medico,
                    IdSisMedico = e.IdSisMedico,
                    Cliente = e.Cliente,
                    IdSisCliente = e.IdSisCliente,
                    Material = e.Material,
                    Observaciones = e.Observaciones,
                    EntregaFlEntregado = e.EntregaFlEntregado,
                    EntregaFechaHora = e.EntregaFechaHora,
                    EntregaObservaciones = e.EntregaObservaciones,
                    EntregaFlProblemas = e.EntregaFlProblemas,
                    EntregaFlTarde = e.EntregaFlTarde,
                    EntregaFlNoEntregado = e.EntregaFlNoEntregado,
                    EntregaDocumentos = e.EntregaDocumentos,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud

                }).Where(x => x.Id == IdEntrega).ToList();
            }
            catch (Exception ex)
            {

                return NotFound();

            }



            return entregasDtoList;
        }

        [HttpGet("EntregasDtoGet")]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> EntregasDtoGet()
        {
            var adminsQueryable = _context.Entregas.AsQueryable();

            List<EntregaDto> entregasDtoList = null;
            try
            {
                var entregas = await adminsQueryable.ToListAsync();
                entregasDtoList = entregas.Select(e => new EntregaDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    IdEmpresa = e.IdEmpresa,
                    IdUsuarioAsignado = e.IdUsuarioAsignado,
                    IdAgendaUsuario = e.IdAgendaUsuario,
                    IdRutaUsuario = e.IdRutaUsuario,
                    FechaIngreso = e.FechaIngreso,
                    IdSisResponsableIngreso = e.IdSisResponsableIngreso,
                    IdSisTramite = e.IdSisTramite,
                    SisTramite = e.SisTramite,
                    Origen = e.Origen,
                    FechaHoraEntrega = e.FechaHoraEntrega,
                    LugarEntrega = e.LugarEntrega,
                    IdSisInstitucion = e.IdSisInstitucion,
                    SectorEntrega = e.SectorEntrega,
                    DireccionEntrega = e.DireccionEntrega,
                    LocalidadEntrega = e.LocalidadEntrega,
                    ProvinciaEntrega = e.ProvinciaEntrega,
                    TelefonoEntrega = e.TelefonoEntrega,
                    Medico = e.Medico,
                    IdSisMedico = e.IdSisMedico,
                    Cliente = e.Cliente,
                    IdSisCliente = e.IdSisCliente,
                    Material = e.Material,
                    Observaciones = e.Observaciones,
                    EntregaFlEntregado = e.EntregaFlEntregado,
                    EntregaFechaHora = e.EntregaFechaHora,
                    EntregaObservaciones = e.EntregaObservaciones,
                    EntregaFlProblemas = e.EntregaFlProblemas,
                    EntregaFlTarde = e.EntregaFlTarde,
                    EntregaFlNoEntregado = e.EntregaFlNoEntregado,
                    EntregaDocumentos = e.EntregaDocumentos,
                    Latitud=e.Latitud  ,
                    Longitud=e.Longitud

                }).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return entregasDtoList;
        }

        [HttpGet("EntregasDtoGetByIds")]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> GetByIds([FromQuery] int[] ids)
        {
            if (ids == null || ids.Length == 0)
                return BadRequest("Debe enviar al menos un id.");

            var entregasDtoList = await _context.Entregas
         .Where(e => ids.Contains(e.Id))
         .Select(e => new EntregaDto
         {
             Id = e.Id,
             IdEmpresa = e.IdEmpresa,
             IdUsuarioAsignado = e.IdUsuarioAsignado,
             IdAgendaUsuario = e.IdAgendaUsuario,
             IdRutaUsuario = e.IdRutaUsuario,
             FechaIngreso = e.FechaIngreso,
             IdSisResponsableIngreso = e.IdSisResponsableIngreso,
             IdSisTramite = e.IdSisTramite,
             SisTramite = e.SisTramite,
             Origen = e.Origen,
             FechaHoraEntrega = e.FechaHoraEntrega,
             LugarEntrega = e.LugarEntrega,
             IdSisInstitucion = e.IdSisInstitucion,
             SectorEntrega = e.SectorEntrega,
             DireccionEntrega = e.DireccionEntrega,
             LocalidadEntrega = e.LocalidadEntrega,
             ProvinciaEntrega = e.ProvinciaEntrega,
             TelefonoEntrega = e.TelefonoEntrega,
             Medico = e.Medico,
             IdSisMedico = e.IdSisMedico,
             Cliente = e.Cliente,
             IdSisCliente = e.IdSisCliente,
             Material = e.Material,
             Observaciones = e.Observaciones,
             EntregaFlEntregado = e.EntregaFlEntregado,
             EntregaFechaHora = e.EntregaFechaHora,
             EntregaObservaciones = e.EntregaObservaciones,
             EntregaFlProblemas = e.EntregaFlProblemas,
             EntregaFlTarde = e.EntregaFlTarde,
             EntregaFlNoEntregado = e.EntregaFlNoEntregado,
             EntregaDocumentos = e.EntregaDocumentos,
             Latitud = e.Latitud,
             Longitud = e.Longitud
         })
         .ToListAsync();

            return Ok(entregasDtoList);
        }
   

        [HttpPost("EntregaPost")]
        public async Task<ActionResult<Entrega>>EntregaPost(EntregaDto entregaDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Entrega entrega = new Entrega
                    {
                       // Id = entregaDto.Id,
                        IdEmpresa = entregaDto.IdEmpresa,
                        IdUsuarioAsignado = entregaDto.IdUsuarioAsignado,
                        IdAgendaUsuario = entregaDto.IdAgendaUsuario,
                        IdRutaUsuario = entregaDto.IdRutaUsuario,
                        FechaIngreso = entregaDto.FechaIngreso,
                        IdSisResponsableIngreso = entregaDto.IdSisResponsableIngreso,
                        IdSisTramite = entregaDto.IdSisTramite,
                        SisTramite = entregaDto.SisTramite,
                        Origen = entregaDto.Origen,
                        FechaHoraEntrega = entregaDto.FechaHoraEntrega,
                        LugarEntrega = entregaDto.LugarEntrega,
                        IdSisInstitucion = entregaDto.IdSisInstitucion,
                        SectorEntrega = entregaDto.SectorEntrega,
                        DireccionEntrega = entregaDto.DireccionEntrega,
                        LocalidadEntrega = entregaDto.LocalidadEntrega,
                        ProvinciaEntrega = entregaDto.ProvinciaEntrega,
                        TelefonoEntrega = entregaDto.TelefonoEntrega,
                        Medico = entregaDto.Medico,
                        IdSisMedico = entregaDto.IdSisMedico,
                        Cliente = entregaDto.Cliente,
                        IdSisCliente = entregaDto.IdSisCliente,
                        Material = entregaDto.Material,
                        Observaciones = entregaDto.Observaciones,
                        //EntregaFlEntregado = entregaDto.EntregaFlEntregado,
                        //EntregaFechaHora = entregaDto.EntregaFechaHora,
                        //EntregaObservaciones = entregaDto.EntregaObservaciones,
                        //EntregaFlProblemas = entregaDto.EntregaFlProblemas,
                        //EntregaFlTarde = entregaDto.EntregaFlTarde,
                        //EntregaFlNoEntregado = entregaDto.EntregaFlNoEntregado,
                        //EntregaDocumentos = entregaDto.EntregaDocumentos
                        Latitud = entregaDto.Latitud,
                        Longitud = entregaDto.Longitud
                    };
                    _context.Entregas.Add(entrega);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok(entrega);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpPut]
        public async Task<ActionResult<Entrega>> EntregaPut(EntregaDto entregaDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Localizacione localizacion = new Localizacione
                    {
                        FechaHoraGps = DateTime.UtcNow,
                        IdUsuario = entregaDto.IdUsuarioAsignado
                    };
                    _context.Localizaciones.Add(localizacion);
                    // 2. Buscar y actualizar la entrega
                    var entregaExistente = await _context.Entregas.FindAsync(entregaDto.Id);
                    if (entregaExistente == null)
                    {
                        await transaction.RollbackAsync();
                        return NotFound();
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok(entregaExistente);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, ex.Message);
                }





            }
        }

        #endregion

 
    }
}
