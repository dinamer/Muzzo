using Muzzo.Core.Models;
using System.Collections.Generic;

namespace Muzzo.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsForUser(string userId);

    }
}