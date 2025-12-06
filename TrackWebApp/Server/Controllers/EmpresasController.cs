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
    public class EmpresasController : ControllerBase
    {
        private readonly TrackContext _context;
        public EmpresasController(TrackContext context)
        {
            _context = context;
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
       
  

    }
}
