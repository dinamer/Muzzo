using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Muzzo.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }

        public DateTime GigDateTime { get; set; }

        public string Venue { get; set; }

        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        public bool IsCanceled { get; private set; }

        public ICollection<Attendance> Attendees { get; private set; }

        public Gig()
        {
            Attendees = new Collection<Attendance>();
        }

        public static Gig Create(string artistId, IEnumerable<ApplicationUser> followers, DateTime dateTime, string venue, byte genreId) {

            Gig gig = new Gig();

            gig.ArtistId = artistId;
            gig.GigDateTime = dateTime;
            gig.Venue = venue;
            gig.GenreId = genreId;

            Notification notification = Notification.GigAdded(gig);


            foreach (var user in followers)
            {
                user.Notify(notification);
            }

            return gig;
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