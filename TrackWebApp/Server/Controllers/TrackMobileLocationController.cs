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
    public class TrackMobileLocationController : ControllerBase
    {
        private readonly TrackContext _context;
        public TrackMobileLocationController(TrackContext context)
        {
            _context = context;
        }

        #region Nuevos



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

                }).Where(x => x.IdUsuario == idUsuario).ToList();
            }
            catch (Exception ex)
            {

                return NotFound();

            }



            return localizacionesDtoList;
        }

       
        [HttpPost("LocalizacionPost")]
        public async Task<ActionResult<Entrega>> LocalizacionPost(LocalizacionesDto localizacionesDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    Localizacione localizacion = new Localizacione
                    {


                        IdUsuario = localizacionesDto.IdUsuario,
                        Latitud = localizacionesDto.Latitud,
                        Longitud = localizacionesDto.Longitud,
                        FechaHoraGps = DateTime.UtcNow,
                        IdEntrega = localizacionesDto.IdEntrega
                    };
                    _context.Localizaciones.Add(localizacion);




                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok(localizacion);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, ex.Message);
                }





            }
        }

        #region EMPRESAS

        [HttpGet("EmpresasDtoGet")]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> EmpresasDtoGet()
        {
            var adminsQueryable = _context.Empresas.AsQueryable();

            List<EmpresaDto> empresasDtoList = null;
            try
            {
                var empresas = await adminsQueryable.ToListAsync();
               
                empresasDtoList = empresas.Select(e => new EmpresaDto
                {
                    // Asigná las propiedades que correspondan
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Cuit = e.Cuit,
                    FlActivo = e.FlActivo
                }).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return empresasDtoList;
        }


        [HttpPost("EmpresaPost")]
        public async Task<ActionResult<Empresa>> EmpresaPost(EmpresaDto empresaDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Empresa empresa = new Empresa
                    {
                         Id = empresaDto.Id,
                        Nombre = empresaDto.Nombre,
                        Cuit = empresaDto.Cuit,
                        FlActivo = empresaDto.FlActivo
                    };
                    _context.Empresas.Add(empresa);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok(empresa);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, ex.Message);
                }
            }
        }

        #endregion
       
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
                    FechaHoraGps = e.FechaHoraGps
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
                    FechaHoraGps = e.FechaHoraGps
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
                    FechaHoraGps = e.FechaHoraGps
                }).Where(x => x.Usuario == Usuario).ToList();
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
                        FechaHoraGps = usuarioDto.FechaHoraGps
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

        #region ENTREGAS

        [HttpGet("EntregasDtoGetByIdUsuarioEntregado/{idUsuario}/{Entregado}")]
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
                    EntregaDocumentos = e.EntregaDocumentos

                }).Where(x => x.IdUsuarioAsignado == IdUsuario && x.EntregaFlEntregado == Entregado).ToList();
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
                    EntregaDocumentos = e.EntregaDocumentos

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
                    EntregaDocumentos = e.EntregaDocumentos

                }).ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return entregasDtoList;
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
                        Id = entregaDto.Id,
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
                        EntregaFlEntregado = entregaDto.EntregaFlEntregado,
                        EntregaFechaHora = entregaDto.EntregaFechaHora,
                        EntregaObservaciones = entregaDto.EntregaObservaciones,
                        EntregaFlProblemas = entregaDto.EntregaFlProblemas,
                        EntregaFlTarde = entregaDto.EntregaFlTarde,
                        EntregaFlNoEntregado = entregaDto.EntregaFlNoEntregado,
                        EntregaDocumentos = entregaDto.EntregaDocumentos

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

        #region IMAGENES

        [HttpPost("SubirImagen")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SubirImagen([FromForm] int idEntrega, [FromForm] IFormFile archivo)
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
        #endregion

        #endregion



        [HttpGet("GetTrackMobileLocation")]
        public async Task<ActionResult<IEnumerable<TrackMobileLocation>>> GetTrackMobileLocation()
        {
            return await _context.TrackMobileLocations.ToListAsync();
        }

        [HttpGet("GetTrackMobileLocationLeaLeft")]
        public async Task<ActionResult<IEnumerable<CoordenadaLeaflet>>> GetTrackMobileLocationLeaLeft()
        {
            IEnumerable<TrackMobileLocation> trackLocations = await _context.TrackMobileLocations.ToListAsync();


            List<CoordenadaLeaflet> coordenadasLeaflet = trackLocations
    .Where(t => !string.IsNullOrEmpty(t.Latitude) && !string.IsNullOrEmpty(t.Longitude)) // Filtrar valores válidos
    .Select(t => new CoordenadaLeaflet
    {
        Lat = t.Latitude!,
        Lng = t.Longitude!
    })
    .ToList();

            return coordenadasLeaflet;

        }

        [HttpGet("GetLastTrackMobileLocation")]
        public async Task<ActionResult<Coordenadas>> GetLastTrackMobileLocation()
        {
            TrackMobileLocation? trackLocation = await _context.TrackMobileLocations
                .Where(t => !string.IsNullOrEmpty(t.Latitude) && !string.IsNullOrEmpty(t.Longitude))
       .OrderByDescending(t => t.Timestamp)
       .FirstOrDefaultAsync();

            Coordenadas coordenadas = new Coordenadas();
            coordenadas.Lat = trackLocation.Latitude;
            coordenadas.Lng = trackLocation.Longitude;



            return coordenadas;

        }

        [HttpGet("{IdCuentaCliente}/{id}")]
        [HttpGet("GetTTrackMobileLocationById/{id}")]
        public async Task<ActionResult<TrackMobileLocation>> GetTTrackMobileLocationById(int id)
        {

            var adminsQueryable = _context.TrackMobileLocations.AsQueryable();

            adminsQueryable = adminsQueryable
              .Where(x => x.Id == id);

            TrackMobileLocation trackMobileLocation = null;
            try
            {
                trackMobileLocation = await adminsQueryable.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                return NotFound();

            }



            return trackMobileLocation;
        }


        [HttpGet("GetTTrackMobileLocationByDeviceId/{DeviceId}")]
        public async Task<ActionResult<List<TrackMobileLocation>>> GetTrackMobileLocationByDeviceId(string DeviceId)
        {

            var adminsQueryable = _context.TrackMobileLocations.AsQueryable();

            adminsQueryable = adminsQueryable
              .Where(x => x.DeviceId == DeviceId);

            List<TrackMobileLocation> trackmobileList = null;
            try
            {
                trackmobileList = await adminsQueryable.ToListAsync();
            }
            catch (Exception ex)
            {

                return NotFound();

            }


            if (trackmobileList.Count == 0)
            {
                return trackmobileList;
            }

            return trackmobileList;
        }

        [HttpPost("PostTrackMobileLocation")]
        public async Task<ActionResult<TrackMobileLocation>> PostTrackMobileLocation(TrackMobileLocation trackmobile)
        {
            trackmobile.Timestamp = DateTime.UtcNow;
            _context.TrackMobileLocations.Add(trackmobile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetTTrackMobileLocationById", new { Id = trackmobile.Id }, trackmobile);
        }




    }
}
