using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Entities;

namespace SistemaNotificacaoEscolarBack.Data.Context;
public class MyDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

    modelBuilder.Entity<User>()
        .HasIndex(u => u.Cpf)
        .IsUnique();
}
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

}