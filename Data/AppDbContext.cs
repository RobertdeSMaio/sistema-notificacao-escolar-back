using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models.Entities;

namespace SistemaEscolar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}