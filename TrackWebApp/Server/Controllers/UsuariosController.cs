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
    public class UsuariosController : ControllerBase
    {
        private readonly TrackContext _context;
        public UsuariosController(TrackContext context)
        {
            _context = context;
        }

       
        #region USUARIOS
        [HttpGet("UsuariosDtoGet")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuariosDtoGet()
        {
            var adminsQueryable = _context.Usuarios.AsQueryable();

            List<UsuarioDto> usuariosDtoList = null;
            try
            {
                var usuarios = await adminsQueryable.ToListAsync();

                usuariosDtoList = usuarios.Select(e => new UsuarioDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Usuario = e.Usuario1,
                    Password = e.Password,
                    IdEmpresa = e.IdEmpresa,
                    AndroidId = e.AndroidId,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    FechaHoraGps = e.FechaHoraGps,
                    FlActivo = e.FlActivo
                  

                }).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return usuariosDtoList;
        }

        [HttpGet("UsuariosDtoGetByIdUsuario/{IdUsuario}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuariosDtoGetByIdUsuario(int IdUsuario)
        {
            var adminsQueryable = _context.Usuarios.AsQueryable();

            List<UsuarioDto> usuariosDtoList = null;
            try
            {
                var usuarios = await adminsQueryable.ToListAsync();

                usuariosDtoList = usuarios.Select(e => new UsuarioDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Usuario = e.Usuario1,
                    Password = e.Password,
                    IdEmpresa = e.IdEmpresa,
                    AndroidId = e.AndroidId,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    FechaHoraGps = e.FechaHoraGps,
                    FlActivo = e.FlActivo
                   
                }).Where(x => x.Id == IdUsuario).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return usuariosDtoList;
        }

        [HttpGet("UsuariosDtoGetByUsuario/{Usuario}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuariosDtoGetByUsuario(string Usuario)
        {
            var adminsQueryable = _context.Usuarios.AsQueryable();

            List<UsuarioDto> usuariosDtoList = null;
            try
            {
                var usuarios = await adminsQueryable.ToListAsync();

                usuariosDtoList = usuarios.Select(e => new UsuarioDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Usuario = e.Usuario1,
                    Password = e.Password,
                    IdEmpresa = e.IdEmpresa,
                    AndroidId = e.AndroidId,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    FechaHoraGps = e.FechaHoraGps,
                    FlActivo = e.FlActivo
                  
                }).Where(x => x.Usuario == Usuario).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return usuariosDtoList;
        }

        [HttpGet("UsuariosDtoGetByIdEmpresa/{IdEmpresa}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> UsuariosDtoGetByIdEmpresa(Guid IdEmpresa)
        {
            var adminsQueryable = _context.Usuarios.AsQueryable();

            List<UsuarioDto> usuariosDtoList = null;
            try
            {
                var usuarios = await adminsQueryable.ToListAsync();

                usuariosDtoList = usuarios.Select(e => new UsuarioDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Usuario = e.Usuario1,
                    Password = e.Password,
                    IdEmpresa = e.IdEmpresa,
                    AndroidId = e.AndroidId,
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    FechaHoraGps = e.FechaHoraGps,
                    FlActivo = e.FlActivo                   
                }).Where(x => x.IdEmpresa == IdEmpresa).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return usuariosDtoList;
        }

        [HttpPost("UsuarioPost")]
        public async Task<ActionResult<Usuario>> UsuarioPost(UsuarioDto usuarioDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Usuario usuario = new Usuario
                    {
                       // Id = usuarioDto.Id,
                        
                        IdEmpresa = usuarioDto.IdEmpresa,
                        Nombre = usuarioDto.Nombre,
                        Usuario1 = usuarioDto.Usuario,
                        Password = usuarioDto.Password,
                        AndroidId = usuarioDto.AndroidId,
                        Latitud = usuarioDto.Latitud,
                        Longitud = usuarioDto.Longitud,
                        FechaHoraGps = usuarioDto.FechaHoraGps,
                        FlActivo = usuarioDto.FlActivo
                     
                    };
                    _context.Usuarios.Add(usuario);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok(usuario);
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
