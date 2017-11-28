using Microsoft.AspNet.Identity;
using Muzzo.Main;
using Muzzo.Main.Dtos;
using Muzzo.Main.Models;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            string followerId = User.Identity.GetUserId();

            Following follow = _unitOfWork.Followings.GetFollowing(followingDto.FolloweeId, followerId); 

            if (follow != null)
                return BadRequest("Allready following.");

            follow = new Following
            {
                FollowerId = followerId,
                FolloweeId= followingDto.FolloweeId
            };

            _unitOfWork.Followings.AddFollowing(follow);
            _unitOfWork.Complete();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            var followerId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(id, followerId);


            if (following == null)
                return NotFound();

            _unitOfWork.Followings.RemoveFollowing(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }


    
}
