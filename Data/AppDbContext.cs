using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Entities;

namespace SistemaNotificacaoEscolarBack.Data.Context;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

}