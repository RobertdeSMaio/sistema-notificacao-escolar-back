using notificationDTO;
using Notification.Service;
using INotification.Service;
using Microsoft.EntityFrameworkCore;
using Notification;
using SistemaNotificacaoEscolarBack.Data.Context;


namespace Notification.Service
{
  public class NotificationService : INotificationService
{
    private readonly MyDbContext _context;

    public NotificationService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateNotificationAsync(NotificationRequest request, string authorName)
    {
        var notification = new NotificationEntitie
    {
        Id = Guid.NewGuid(),
        Title = request.Title ?? "",
        Content = request.Content ?? "",
        Target = request.Target ?? "Todos",
        Author = authorName ?? "Admin",
        CreatedAt = DateTime.UtcNow,
        RecipientsIds = string.Join(",", request.RecipientsIds ?? new List<string>())
    };

        _context.Notifications.Add(notification);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<NotificationEntitie>> GetAllAsync()
    {
        return await _context.Notifications.OrderByDescending(n => n.CreatedAt).ToListAsync();
    }
}
}