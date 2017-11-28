using Muzzo.Main.Models;
using Muzzo.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Muzzo.DAL.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GigRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        public IEnumerable<Gig> GetGigsUserAttending(string attendeeId)
        {
            return _dbContext.Attendees
                                   .Where(a => a.AttendeeId == attendeeId)
                                   .Select(a => a.Gig)
                                   .Include(g => g.Artist)
                                   .Include(g => g.Genre)
                                   .ToList();
        }


        public void AddGig(Gig gig) {

            _dbContext.Gigs.Add(gig);
        }


        public IEnumerable<Gig> GetAllUpcomingGigs()
        {
            return _dbContext.Gigs
                             .Include(g => g.Artist)
                             .Include(g => g.Genre)
                             .Where(g => g.GigDateTime > DateTime.Now && !g.IsCanceled)
                             .ToList();

        }

        public IEnumerable<Gig> SearchGigsByGenreVenueOrArtist(string searchTerm)
        {
            return _dbContext.Gigs
                             .Include(g => g.Artist)
                             .Include(g => g.Genre)
                             .Where(g => (g.GigDateTime > DateTime.Now && !g.IsCanceled) &&
                                         (g.Artist.Name.Contains(searchTerm) ||
                                          g.Genre.Name.Contains(searchTerm) ||
                                          g.Venue.Contains(searchTerm)))
                             .ToList();
        }

        public Gig GetGig(int gigId)
        {
            return _dbContext.Gigs
                      .Include(g => g.Artist)
                      .Include(g => g.Genre)
                      .SingleOrDefault(g => g.Id == gigId);
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _dbContext.Gigs
                            .Include(g => g.Attendees.Select(a => a.Attendee))
                            .Single(g => g.Id == gigId);
        }

        public Gig GetGigWithAttendeesAndArtistFollowers(int gigId)
        {
            return _dbContext.Gigs
                      .Include(g => g.Artist.Followers)
                      .Include(g => g.Attendees)
                      .Include(g => g.Genre)
                      .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId)
        {
            return _dbContext.Gigs
                             .Where(g => g.ArtistId == artistId && g.GigDateTime >= DateTime.Now && g.IsCanceled != true)
                             .Include(g => g.Genre)
                             .ToList();

        }


    }
}