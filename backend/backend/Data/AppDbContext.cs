using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario>? usuario { get; set; }
        public DbSet<Ads>? ads { get; set; }
        public DbSet<Categoria>? categorias { get; set; }
        public DbSet<States>? states { get; set; } 
    }
}
