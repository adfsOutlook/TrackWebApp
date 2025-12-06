
using Project.Server.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Project.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}