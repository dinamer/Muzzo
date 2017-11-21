using Muzzo.Models;
using Muzzo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Muzzo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index(string searchQuery = null)
        {
            IEnumerable<Gig> gigs = _dbContext.Gigs
                                    .Include(g => g.Artist)
                                    .Include(g => g.Genre)
                                    .Where(g => g.GigDateTime > DateTime.Now && !g.IsCanceled)
                                    .ToList();

            if (!string.IsNullOrWhiteSpace(searchQuery)) {

                gigs = gigs.Where(g => g.Artist.Name.Contains(searchQuery) || 
                                  g.Genre.Name.Contains(searchQuery) ||
                                  g.Venue.Contains(searchQuery)); 
            }
           

            GigViewModel model = new GigViewModel {

                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming gigs",
                SearchTerm = searchQuery

            };

            return View("Gigs", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}