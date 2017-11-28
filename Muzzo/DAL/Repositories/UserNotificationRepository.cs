using Muzzo.Core.Models;
using Muzzo.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.DAL.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserNotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        public IEnumerable<UserNotification> GetUserNotificationsForUser(string userId)
        {
            return _dbContext.UserNotifications
                   .Where(un => un.UserId == userId && !un.IsRead)
                   .ToList();
        }
        
    }
}