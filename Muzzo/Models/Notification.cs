using System;
using System.ComponentModel.DataAnnotations;

namespace Muzzo.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public int GigId { get; set; }
        public Gig Gig { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

    }
}