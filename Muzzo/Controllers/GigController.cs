using Microsoft.AspNet.Identity;
using Muzzo.Models;
using Muzzo.ViewModels;
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


            return RedirectToAction("Index", "Home");
        }
    }
}