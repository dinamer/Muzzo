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
            GigFormViewModel model = new GigFormViewModel
            {
                Genres = _dbContext.Genres.ToList(),
                Heading = "Add a gig"
            };

            
            return View("GigForm", model);
        }

        //Creates a gig
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel gigViewModel)
        {
            if (!ModelState.IsValid)
            {
                gigViewModel.Genres = _dbContext.Genres.ToList();

                return View("GigForm", gigViewModel);

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


        //Gets the form for editing a gig
        [Authorize]
        public ActionResult Edit(int id)
        {
            string userId = User.Identity.GetUserId();

            Gig gig = _dbContext.Gigs.Single(g => g.Id == id && g.ArtistId == userId);

            GigFormViewModel model = new GigFormViewModel
            {
                Id = gig.Id,
                Genres = _dbContext.Genres.ToList(),
                Genre = gig.GenreId,
                Venue = gig.Venue,
                Date = gig.GigDateTime.ToString("dd.MM.yyyy"),
                Time = gig.GigDateTime.ToString("HH:mm"),
                Heading = "Edit a gig"
            };


            return View("GigForm", model);
        }


        //Updates a gig
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel gigViewModel)
        {
            if (!ModelState.IsValid)
            {
                gigViewModel.Genres = _dbContext.Genres.ToList();

                return View("GigForm", gigViewModel);

            }

            string userId = User.Identity.GetUserId();
            Gig gigFromDb = _dbContext.Gigs.Single(g => g.Id == gigViewModel.Id && g.ArtistId == userId);

            gigFromDb.GigDateTime = gigViewModel.GetDateTime();
            gigFromDb.Venue = gigViewModel.Venue;
            gigFromDb.GenreId = gigViewModel.Genre;
           

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