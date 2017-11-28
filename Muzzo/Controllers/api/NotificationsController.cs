using AutoMapper;
using Microsoft.AspNet.Identity;
using Muzzo.Main;
using Muzzo.Main.Dtos;
using Muzzo.Main.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var notifications = _unitOfWork.Notifications.GetNewNotificationsForUser(User.Identity.GetUserId());


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

        [HttpPost]
        public IHttpActionResult MarkNotificationsAsRead()
        {
            var notifications = _unitOfWork.UserNotifications
                               .GetUserNotificationsForUser(User.Identity.GetUserId());

            notifications.ToList().ForEach(un => un.NotificationRead());

            _unitOfWork.Complete();
         
           
            return Ok();
        }
    
    }
}
