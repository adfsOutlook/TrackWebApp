using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Server;
using Project.Server.Models;
using System.Reflection;
namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        private readonly TrackContext _context;
        public UtilsController(TrackContext context)
        {
            _context = context;
        }


        [HttpGet("build-info")]
        public IActionResult GetBuildInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var filePath = assembly.Location;

            var buildDate = System.IO.File.GetLastWriteTime(filePath);

            return Ok(new
            {
                BuildDate = buildDate.ToString("yyyy-MM-dd HH:mm:ss"),
                UtcBuildDate = buildDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss 'UTC'"),
                Version = assembly.GetName().Version?.ToString()
            });
        }
    }



}
