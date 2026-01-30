using Microsoft.EntityFrameworkCore;
using sistema_notificacao_escolar_back.Models.Entities;

namespace sistema_notificacao_escolar_back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}