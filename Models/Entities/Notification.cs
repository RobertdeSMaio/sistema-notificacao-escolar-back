using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Notification
{
    public class NotificationEntitie
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public string Target { get; set; }
        
        public string Author { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string RecipientsIds { get; set; }
    }
}