using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Muzzo.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }

        public DateTime GigDateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        public bool IsCanceled { get; private set; }

        public ICollection<Attendance> Attendees { get; private set; }

        public Gig()
        {
            Attendees = new Collection<Attendance>();
        }


        public void Cancel() {

            IsCanceled = true;

            Notification notification = Notification.GigCanceled(this);

            foreach (var user in Attendees.Select(a => a.Attendee))
            {
                user.Notify(notification);
            }
        }

        public void Update(DateTime newDateTime, string venue, byte genre) {

            Notification notification = Notification.GigUpdated(this, GigDateTime, Venue);

            GigDateTime = newDateTime;
            Venue = venue;
            GenreId = genre;

            foreach (var user in Attendees.Select(a => a.Attendee))
            {
                user.Notify(notification);
            }
        }
    }
}