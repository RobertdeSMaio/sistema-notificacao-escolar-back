using notificationDTO;
using Notification.Service;
using Microsoft.AspNetCore.Mvc;
using INotification.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Controller
{

  [ApiController]
  [Route("api/[controller]")]
  public class NotificationController : ControllerBase
  {
      private readonly INotificationService _notificationService;

      public NotificationController(INotificationService notificationService)
      {
          _notificationService = notificationService;
      }

      [HttpPost]
      public async Task<IActionResult> Create([FromBody] NotificationRequest request)
      {
          var author = User.Identity?.Name ?? "Admin";

          var sucesso = await _notificationService.CreateNotificationAsync(request, author);

          if (!sucesso) return BadRequest("Erro ao criar notificação.");

          return Ok();
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
          return Ok(await _notificationService.GetAllAsync());
      }
  }

}