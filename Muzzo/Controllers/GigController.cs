using Microsoft.AspNet.Identity;
using Muzzo.Models;
using Muzzo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Muzzo.Controllers
{
    public class GigController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public GigController()
        {
            _dbContext = new ApplicationDbContext();
        }

        //Gets the form for adding a gig
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            AddGigFormViewModel model = new AddGigFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            
            return View(model);
        }

        //Creates a gig
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddGigFormViewModel gigViewModel)
        {
            if (!ModelState.IsValid)
            {
                gigViewModel.Genres = _dbContext.Genres.ToList();

                return View("Create", gigViewModel);

            }
                

            Gig gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GigDateTime = gigViewModel.GetDateTime(),
                Venue = gigViewModel.Venue,
                GenreId = gigViewModel.Genre
            };

            _dbContext.Gigs.Add(gig);
            _dbContext.SaveChanges();


            return RedirectToAction("MyUpcomingGigs", "Gig");
        }


        [Authorize]
        public ActionResult AttendingGigs()
        {
            string atendeeId = User.Identity.GetUserId();

            IEnumerable<Gig> gigs = _dbContext.Attendees
                                    .Where(a => a.AttendeeId == atendeeId)
                                    .Select(a => a.Gig)
                                    .Include(g => g.Artist)
                                    .Include(g => g.Genre)
                                    .ToList();
            GigViewModel model = new GigViewModel
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm attending"

            };


            return View("Gigs", model);
        }

        //Gets artist's upcoming gigs
        [Authorize]
        public ActionResult MyUpcomingGigs()
        {
            string artistId = User.Identity.GetUserId();

            IEnumerable<Gig> upcomingGigs = _dbContext.Gigs
                             .Where(g => g.ArtistId == artistId && g.GigDateTime >= DateTime.Now)
                             .Include(g => g.Genre)
                             .ToList();

            return View(upcomingGigs);
        }


    }
}