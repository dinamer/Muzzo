using AutoMapper;
using Microsoft.AspNet.Identity;
using Muzzo.Dtos;
using Muzzo.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Muzzo.Controllers
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public NotificationsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _dbContext.UserNotifications
                                .Where(un => un.UserId == userId && !un.IsRead)
                                .Select(un => un.Notification)
                                .Include(n => n.Gig.Artist)
                                .ToList();


            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
            
            //return notifications.Select(n => new NotificationDto() {

            //        DateTime = n.DateTime,
            //        Type = n.Type,
            //        OriginalDateTime = n.OriginalDateTime,
            //        OriginalVenue = n.OriginalVenue,

            //        Gig = new GigDto
            //        {
            //            Id = n.Gig.Id,
            //            GigDateTime = n.Gig.GigDateTime,
            //            Venue = n.Gig.Venue,
            //            IsCanceled = n.Gig.IsCanceled,

            //            Artist = new UserDto
            //            {
            //                Id = n.Gig.Artist.Id,
            //                Name = n.Gig.Artist.Name
            //            }
            //        }
            //});
        }
    }
}
