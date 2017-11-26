using Muzzo.Core.Models;
using System.Linq;

namespace Muzzo.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public string ArtistId { get; set; }
        public string Artist { get; set; }

        public string GigDate { get; set; }

        public string GigTime { get; set; }

        public string Venue { get; set; }

        public bool IsFollowing { get; set; }

        public bool IsAttending { get; set; }

        public bool ShowActions{ get; set; }


        public GigDetailsViewModel()
        {
                
        }

        public GigDetailsViewModel(Gig gig, string user, bool authenticated)
        {
            ArtistId = gig.ArtistId;
            Artist = gig.Artist.Name;
            GigDate = gig.GigDateTime.ToString("dd.MM.yyyy");
            GigTime = gig.GigDateTime.ToString("HH:mm");
            Venue = gig.Venue;
            IsAttending = gig.Attendees.Any(a => a.AttendeeId == user);
            IsFollowing = gig.Artist.IsFollowedBy(user);
            ShowActions = authenticated;
        }


        public static GigDetailsViewModel Create(Gig gig, string userId, bool authenticated) {

            return new GigDetailsViewModel(gig, userId, authenticated);
        }
    }
}