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
    public class ArchivosController : ControllerBase
    {
        private readonly TrackContext _context;
        public ArchivosController(TrackContext context)
        {
            _context = context;
        }



        [HttpGet("BajarArchivo/{id}")]
        public async Task<IActionResult> BajarArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);

            if (archivo == null || archivo.Contenido == null || archivo.TipoMime == null)
                return NotFound();

            return File(
                archivo.Contenido,
                archivo.TipoMime,
                archivo.NombreArchivo // 👈 importante para descarga
            );
        }


        [HttpGet("GetArchivosByIdEntrega/{IdEntrega}")]
        public async Task<ActionResult<IEnumerable<ArchivosDto>>> GetArchivosByIdEntrega(int IdEntrega)
        {
            var archivos = await _context.Archivos
                .Where(a => a.IdEntrega == IdEntrega)
                .ToListAsync();

            var result = archivos.Select(a => new ArchivosDto
            {
                Id = a.Id,
                IdEntrega = a.IdEntrega,
                NombreArchivo = a.NombreArchivo,
                TipoMime = a.TipoMime,
                TamanoBytes = a.TamanoBytes,
                FechaAlta = a.FechaAlta,
                Contenido = null,           // no mandar binario
                ContenidoBase64 = a.Contenido != null
                ? $"data:{a.TipoMime};base64,{Convert.ToBase64String(a.Contenido)}" : null
            });

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ArchivosDto>> SubirArchivo([FromBody] ArchivosDto dto)
        {
            if (string.IsNullOrEmpty(dto.ContenidoBase64))
                return BadRequest("Contenido del archivo vacío");

            if (string.IsNullOrEmpty(dto.NombreArchivo))
                return BadRequest("Nombre de archivo obligatorio");

            byte[] contenido;
            try
            {
                var base64 = dto.ContenidoBase64;
                if (base64.Contains(","))
                    base64 = base64.Substring(base64.IndexOf(",") + 1);

                contenido = Convert.FromBase64String(base64);
            }
            catch
            {
                return BadRequest("El contenido base64 no es válido");
            }

            var archivo = new Archivo
            {
                IdEntrega = dto.IdEntrega,
                NombreArchivo = dto.NombreArchivo,
                TipoMime = dto.TipoMime ?? "application/octet-stream",
                TamanoBytes = contenido.Length,
                Contenido = contenido
            };

            _context.Archivos.Add(archivo);
            await _context.SaveChangesAsync();

            var result = new ArchivosDto
            {
                Id = archivo.Id,
                IdEntrega = archivo.IdEntrega,
                NombreArchivo = archivo.NombreArchivo,
                TipoMime = archivo.TipoMime,
                TamanoBytes = archivo.TamanoBytes
            };

            return CreatedAtAction(
                nameof(GetArchivosByIdEntrega),
                new { idEntrega = archivo.IdEntrega },
                result
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo == null)
                return NotFound();

            _context.Archivos.Remove(archivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
