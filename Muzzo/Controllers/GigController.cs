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

        //Gets form for adding a gig
        [HttpGet]
        public ActionResult Create()
        {
            AddGigFormViewModel model = new AddGigFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            
            return View(model);
        }
    }
}