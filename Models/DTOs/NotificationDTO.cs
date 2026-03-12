using Notification.Controller;
using Notification.Service;

namespace notificationDTO{

  public class NotificationRequest
  {
      public string Title { get; set; }
      public string Content { get; set; }
      public string Target { get; set; }
      public List<string> RecipientsIds { get; set; }
  }
}