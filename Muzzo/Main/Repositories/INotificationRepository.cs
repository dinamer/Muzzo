using Muzzo.Main.Models;
using System.Collections.Generic;

namespace Muzzo.Main.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);

    }
}