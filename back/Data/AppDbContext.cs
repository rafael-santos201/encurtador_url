using Microsoft.EntityFrameworkCore;
using encurtador_url.back.Models;

namespace encurtador_url.back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UrlMapping> UrlMappings { get; set; }

    }
}
