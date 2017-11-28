using Microsoft.AspNet.Identity;
using Muzzo.Main;
using Muzzo.Main.Models;
using Muzzo.Main.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Muzzo.Controllers
{
    public class HomeController : Controller
    {       
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public ActionResult Index(string searchQuery = null)
        {
            IEnumerable<Gig> gigs = _unitOfWork.Gigs.GetAllUpcomingGigs();

            if (!string.IsNullOrWhiteSpace(searchQuery)) {

                gigs = _unitOfWork.Gigs.SearchGigsByGenreVenueOrArtist(searchQuery);
            }

            var attendances = _unitOfWork.Attendances
                               .GetFutureUserAttendances(User.Identity.GetUserId())
                               .ToLookup(a => a.GigId);


            GigViewModel model = new GigViewModel {

                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming gigs",
                SearchTerm = searchQuery,
                Attendances = attendances
            };

            return View("Gigs", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}