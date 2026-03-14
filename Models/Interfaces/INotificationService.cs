using notificationDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notification.Controller;
using Notification;

namespace INotification.Service{
  public interface INotificationService
  {
    Task<bool> CreateNotificationAsync(NotificationRequest request, string authorName);
    Task<List<NotificationEntitie>> GetAllAsync(string? userId);
  }
}