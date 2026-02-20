using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Entities;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

}