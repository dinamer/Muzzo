using Muzzo.Main.Models;
using Muzzo.Main.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Muzzo.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IEnumerable<Notification> GetNewNotificationsForUser(string userId)
        {
            return _dbContext.UserNotifications
                             .Where(un => un.UserId == userId && !un.IsRead)
                             .Select(un => un.Notification)
                             .Include(n => n.Gig.Artist)
                             .ToList();
        }

    }
}