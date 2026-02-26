using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Entities;

namespace SistemaNotificacaoEscolarBack.Data.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

}