using Muzzo.Core;
using Muzzo.Core.Repositories;
using Muzzo.Persistence.Repositories;

namespace Muzzo.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IGigRepository Gigs { get; private set; }

        public IAttendanceRepository Attendances { get; private set; }

        public IGenreRepository Genres { get; private set; }

        public IFollowingRepository Followings { get; private set; }

        public IUserNotificationRepository UserNotifications { get; private set; }

        public INotificationRepository Notifications { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Gigs = new GigRepository(dbContext);
            Attendances = new AttendanceRepository(dbContext);
            Genres = new GenreRepository(dbContext);
            Followings = new FollowingRepository(dbContext);
            UserNotifications = new UserNotificationRepository(dbContext);
            Notifications = new NotificationRepository(dbContext);

        }

        public void Complete() {

            _dbContext.SaveChanges();
        }
    }
}