using Muzzo.Main.Models;
using System.Collections.Generic;

namespace Muzzo.Main.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotificationsForUser(string userId);


    }
}