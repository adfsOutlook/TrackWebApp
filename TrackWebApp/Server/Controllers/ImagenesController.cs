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
    public class ImagenesController : ControllerBase
    {
        private readonly TrackContext _context;
        public ImagenesController(TrackContext context)
        {
            _context = context;
        }



        #region IMAGENES

        [HttpPost("SubirImagen2")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SubirImagen2([FromForm] int idEntrega, [FromForm] IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("No se recibió ninguna imagen.");

            using var ms = new MemoryStream();
            await archivo.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var nuevaImagen = new Imagene
            {
                IdEntrega = idEntrega,
                Contenido = bytes,
                TipoMime = archivo.ContentType
            };
            _context.Imagenes.Add(nuevaImagen);
            await _context.SaveChangesAsync();

            return Ok(new { nuevaImagen.Id });
        }



        [HttpGet("BajarImagen/{id}")]
        public async Task<IActionResult> BajarImagen(int id)
        {
            var imagen = await _context.Imagenes.FindAsync(id);

            if (imagen == null || imagen.Contenido == null || imagen.TipoMime == null)
                return NotFound();

            // Retornamos el archivo con el contenido y el tipo MIME correspondiente
            return File(imagen.Contenido, imagen.TipoMime);
        }

        [HttpGet("GetImagenesByIdEntrega/{IdEntrega}")]
        public async Task<ActionResult<IEnumerable<Imagene>>> GetImagenesByIdEntrega(int IdEntrega)
        {
            var imagenes = await _context.Imagenes
            .Where(i => i.IdEntrega == IdEntrega)
            .ToListAsync();

            var result = imagenes.Select(i => new ImagenesDto
            {
                Id = i.Id,
                IdEntrega = i.IdEntrega,
                Contenido = null, // opcional, para no mandar binario pesado
                TipoMime = i.TipoMime,
                ContenidoBase64 = i.Contenido != null
                    ? $"data:{i.TipoMime};base64,{Convert.ToBase64String(i.Contenido)}"
                    : null
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ImagenesDto>> SubirImagen([FromBody] ImagenesDto dto)
        {
            if (string.IsNullOrEmpty(dto.ContenidoBase64))
                return BadRequest("Contenido de la imagen vacío");

            // Remover prefijo "data:image/jpeg;base64," si viene incluido
            var base64 = dto.ContenidoBase64;
            if (base64.Contains(","))
                base64 = base64.Substring(base64.IndexOf(",") + 1);

            byte[] contenido;
            try
            {
                contenido = Convert.FromBase64String(base64);
            }
            catch
            {
                return BadRequest("El contenido base64 no es válido");
            }

            var imagen = new Imagene
            {
                IdEntrega = dto.IdEntrega,
                TipoMime = dto.TipoMime,
                Contenido = contenido
            };

            _context.Imagenes.Add(imagen);
            await _context.SaveChangesAsync();

            // Devolver el DTO recién guardado
            var result = new ImagenesDto
            {
                Id = imagen.Id,
                IdEntrega = imagen.IdEntrega,
                TipoMime = imagen.TipoMime,
                ContenidoBase64 = $"data:{imagen.TipoMime};base64,{dto.ContenidoBase64}"
            };

            return CreatedAtAction(nameof(GetImagenesByIdEntrega),
                new { idEntrega = imagen.IdEntrega }, result);
        }

        #endregion


    }
}
