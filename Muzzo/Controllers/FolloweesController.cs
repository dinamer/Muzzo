using Microsoft.AspNet.Identity;
using Muzzo.Core;
using System.Web.Mvc;

namespace Muzzo.Controllers
{
    public class FolloweesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {       
            _unitOfWork = unitOfWork;
        }


        // GET: Folowees
        [Authorize]
        public ActionResult Index()
        {                           
            return View(_unitOfWork.Followings.GetFolloweesByUser(User.Identity.GetUserId()));
        }
    }
}