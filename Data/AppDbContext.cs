using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Entities;
using Notification;

namespace SistemaNotificacaoEscolarBack.Data.Context;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<NotificationEntitie> Notifications { get; set; }

}