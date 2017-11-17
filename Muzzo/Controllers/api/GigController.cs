using Microsoft.AspNet.Identity;
using Muzzo.Models;
using System.Linq;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class GigController : ApiController
    {

        private ApplicationDbContext _dbContext;

        public GigController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [HttpDelete]
        public IHttpActionResult CancelGig(int id)
        {
            string artistId = User.Identity.GetUserId();
            var gig = _dbContext.Gigs.Single(g => g.Id == id && g.ArtistId == artistId);

            if (gig.IsCanceled)
                return NotFound();

            gig.IsCanceled = true;

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
