using Microsoft.AspNet.Identity;
using Muzzo.Models;
using System;
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

            Notification notification = new Notification {
                Gig = gig,
                DateTime = DateTime.Now,
                Type = NotificationType.GigCanceled
            };

            _dbContext.Notifications.Add(notification);

            var attendees = _dbContext.Attendees.Where(a => a.GigId == gig.Id)
                            .Select(a => a.Attendee)
                            .ToList();

            foreach (var user in attendees) {

                UserNotification userNotification = new UserNotification
                {
                    Notification = notification,
                    User = user
                };

            _dbContext.UserNotifications.Add(userNotification);
            }


            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
