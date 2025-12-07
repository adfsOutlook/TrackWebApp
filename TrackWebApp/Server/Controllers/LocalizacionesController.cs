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
    public class LocalizacionesController : ControllerBase
    {
        private readonly TrackContext _context;
        public LocalizacionesController(TrackContext context)
        {
            _context = context;
        }





        [HttpGet("LocalizacionesDtoGetByIdUsuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<LocalizacionesDto>>> LocalizacionesDtoGetByIdUsuario(int idUsuario)
        {

            var adminsQueryable = _context.Localizaciones.AsQueryable();

            List<LocalizacionesDto> localizacionesDtoList = null;
            try
            {
                var localizaciones = await adminsQueryable.ToListAsync();
                localizacionesDtoList = localizaciones.Select(e => new LocalizacionesDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    IdUsuario = e.IdUsuario,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    FechaHoraGps = e.FechaHoraGps,
                    IdEntrega = e.IdEntrega,
                    Distancia = e.Distancia,
                    Tiempo = e.Tiempo,
                    HoraLlegada = e.HoraLlegada

                }).Where(x => x.IdUsuario == idUsuario).ToList();
            }
            catch (Exception ex)
            {

                return NotFound();

            }



            return localizacionesDtoList;
        }

        [HttpGet("LocalizacionesDtoGetByIdEntrega/{IdEntrega}")]
        public async Task<ActionResult<IEnumerable<LocalizacionesDto>>> LocalizacionesDtoGetByIdEntrega(int IdEntrega)
        {

            var adminsQueryable = _context.Localizaciones.AsQueryable();

            List<LocalizacionesDto> localizacionesDtoList = null;
            try
            {
                var localizaciones = await adminsQueryable.ToListAsync();
                localizacionesDtoList = localizaciones.Select(e => new LocalizacionesDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    IdUsuario = e.IdUsuario,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    FechaHoraGps = e.FechaHoraGps,
                    IdEntrega = e.IdEntrega,
                    Distancia = e.Distancia,
                    Tiempo = e.Tiempo,
                    HoraLlegada = e.HoraLlegada


                }).Where(x => x.IdEntrega == IdEntrega).ToList();
            }
            catch (Exception ex)
            {

                return NotFound();

            }



            return localizacionesDtoList;
        }



        [HttpPost("LocalizacionPost")]
        public async Task<ActionResult<LocalizacionesDto>> LocalizacionPost(LocalizacionesDto localizacionesDto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var localizacion = new Localizacione
                {
                    IdUsuario = localizacionesDto.IdUsuario,
                    Latitud = localizacionesDto.Latitud,
                    Longitud = localizacionesDto.Longitud,
                    FechaHoraGps = DateTime.UtcNow,
                    IdEntrega = localizacionesDto.IdEntrega
                };

                _context.Localizaciones.Add(localizacion);
                await _context.SaveChangesAsync();

                localizacionesDto.Id = localizacion.Id;
                localizacionesDto.FechaHoraGps = localizacion.FechaHoraGps;

                await transaction.CommitAsync();
                return Ok(localizacionesDto);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("LocalizacionesDtoGetLastByIdUsuario/{idUsuario}")]
        public async Task<ActionResult<LocalizacionesDto>> LocalizacionesDtoGetLastByIdUsuario(int idUsuario)
        {
            try
            {
                var localizacionDto = await _context.Localizaciones
                    .Where(e => e.IdUsuario == idUsuario)
                    .OrderByDescending(e => e.FechaHoraGps)
                    .Select(e => new LocalizacionesDto
                    {
                        Id = e.Id,
                        IdUsuario = e.IdUsuario,
                        Latitud = e.Latitud,
                        Longitud = e.Longitud,
                        FechaHoraGps = e.FechaHoraGps,
                        IdEntrega = e.IdEntrega,
                        Distancia = e.Distancia,
                        Tiempo = e.Tiempo,
                        HoraLlegada = e.HoraLlegada
                    })
                    .FirstOrDefaultAsync();

                if (localizacionDto == null)
                    return NotFound();

                return Ok(localizacionDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener la última localización del usuario.");
            }
        }

        [HttpGet("LocalizacionesDtoGetLastByIdEntrega/{idEntrega}")]
        public async Task<ActionResult<LocalizacionesDto>> LocalizacionesDtoGetLastByIdEntrega(int idEntrega)
        {
            try
            {
                var localizacionDto = await _context.Localizaciones
                    .Where(e => e.IdEntrega == idEntrega)
                    .OrderByDescending(e => e.FechaHoraGps)
                    .Select(e => new LocalizacionesDto
                    {
                        Id = e.Id,
                        IdUsuario = e.IdUsuario,
                        Latitud = e.Latitud,
                        Longitud = e.Longitud,
                        FechaHoraGps = e.FechaHoraGps,
                        IdEntrega = e.IdEntrega,
                        Distancia = e.Distancia,
                        Tiempo = e.Tiempo,
                        HoraLlegada = e.HoraLlegada
                    })
                    .FirstOrDefaultAsync();

                if (localizacionDto == null)
                    return NotFound();

                return Ok(localizacionDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener la última localización del usuario.");
            }
        }

    }
}
