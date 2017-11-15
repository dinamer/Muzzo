using Microsoft.AspNet.Identity;
using Muzzo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Muzzo.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public FolloweesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Folowees
        [Authorize]
        public ActionResult Index()
        {
            var followerId = User.Identity.GetUserId();

            IEnumerable<ApplicationUser> followees = _dbContext.Followings
                                                    .Where(f => f.FollowerId == followerId)
                                                    .Select(f => f.Followee)
                                                    .ToList();
                           

            return View(followees);
        }
    }
}