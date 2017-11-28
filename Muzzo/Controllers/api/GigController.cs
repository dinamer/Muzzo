using Microsoft.AspNet.Identity;
using Muzzo.Core;
using Muzzo.DAL;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class GigController : ApiController
    {

        private IUnitOfWork _unitOfWork;

        public GigController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpDelete]
        public IHttpActionResult CancelGig(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig == null)
                return NotFound();

            if (gig.IsCanceled)
                return NotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return Unauthorized();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
