using Microsoft.AspNet.Identity;
using Muzzo.Dtos;
using Muzzo.Models;
using System.Linq;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }



        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            string followerId = User.Identity.GetUserId();

            if (_dbContext.Followings.Any(f => f.FollowerId == followerId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Allready following.");

            Following follow = new Following
            {
                FollowerId = followerId,
                FolloweeId= followingDto.FolloweeId
            };

            _dbContext.Followings.Add(follow);
            _dbContext.SaveChanges();


            return Ok();
        }
    }

    
}
