using Muzzo.Main.Models;
using System.Collections.Generic;

namespace Muzzo.Main.Repositories
{
    public interface IGigRepository
    {
        void AddGig(Gig gig);
        IEnumerable<Gig> GetAllUpcomingGigs();
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
        IEnumerable<Gig> SearchGigsByGenreVenueOrArtist(string searchTerm);
        IEnumerable<Gig> GetGigsUserAttending(string attendeeId);
        Gig GetGigWithAttendees(int gigId);
        Gig GetGigWithAttendeesAndArtistFollowers(int gigId);
      
    }
}