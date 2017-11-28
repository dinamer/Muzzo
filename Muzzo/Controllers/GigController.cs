using Microsoft.AspNet.Identity;
using Muzzo.Main;
using Muzzo.Main.Models;
using Muzzo.Main.ViewModels;
using System.Linq;
using System.Web.Mvc;


namespace Muzzo.Controllers
{
    public class GigController : Controller
    {      
        private IUnitOfWork _unitOfWork;

        public GigController(IUnitOfWork unitOfWork)
        {          
            _unitOfWork = unitOfWork;
        }

        //Gets the form for adding a gig
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            GigFormViewModel model = new GigFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenres(),
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
                gigViewModel.Genres = _unitOfWork.Genres.GetGenres();

                return View("GigForm", gigViewModel);

            }

            _unitOfWork.Gigs.AddGig(Gig.Create(User.Identity.GetUserId(),
                                    _unitOfWork.Followings.GetFollowersByArtist(User.Identity.GetUserId()), 
                                    gigViewModel.GetDateTime(),
                                    gigViewModel.Venue,
                                    gigViewModel.Genre));

            _unitOfWork.Complete();

            return RedirectToAction("MyUpcomingGigs", "Gig");
        }


        //Gets the form for editing a gig
        [Authorize]
        public ActionResult Edit(int id)
        {
            Gig gig = _unitOfWork.Gigs.GetGig(id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            GigFormViewModel model = new GigFormViewModel
            {
                Id = gig.Id,
                Genres = _unitOfWork.Genres.GetGenres(),
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
                gigViewModel.Genres = _unitOfWork.Genres.GetGenres();

                return View("GigForm", gigViewModel);

            }

            Gig gig = _unitOfWork.Gigs.GetGigWithAttendees(gigViewModel.Id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Update(gigViewModel.GetDateTime(), gigViewModel.Venue, gigViewModel.Genre);

            _unitOfWork.Complete();

            return RedirectToAction("MyUpcomingGigs", "Gig");
        }


        [Authorize]
        public ActionResult AttendingGigs()
        {
            string attendeeId = User.Identity.GetUserId();

            GigViewModel model = new GigViewModel
            {
                UpcomingGigs = _unitOfWork.Gigs.GetGigsUserAttending(attendeeId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm attending",
                Attendances = _unitOfWork.Attendances.GetFutureUserAttendances(attendeeId).ToLookup(a => a.GigId)

            };


            return View("Gigs", model);
        }

        //Gets artist's upcoming gigs
        [Authorize]
        public ActionResult MyUpcomingGigs()
        {
            return View(_unitOfWork.Gigs.GetUpcomingGigsByArtist(User.Identity.GetUserId()));
        }

        //Search gigs by artist's name, venue or genre
        public ActionResult Search(GigViewModel gigViewModel)
        {
            return RedirectToAction("Index", "Home", new { searchQuery = gigViewModel.SearchTerm });

        }

        //Gets gig's details
        public ActionResult Details(int gigId)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendeesAndArtistFollowers(gigId);

            if (gig == null)
                return HttpNotFound();

            return View(GigDetailsViewModel.Create(gig, User.Identity.GetUserId(), User.Identity.IsAuthenticated));
        }



       
    }
}


































































