using Muzzo.Core.Repositories;

namespace Muzzo.Core
{
    public interface IUnitOfWork
    {
        
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IGenreRepository Genres { get; }
        IFollowingRepository Followings { get; }
        IUserNotificationRepository UserNotifications { get; }
        INotificationRepository Notifications { get;  }
        void Complete();
    }
}