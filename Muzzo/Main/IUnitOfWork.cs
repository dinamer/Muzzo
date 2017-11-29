using Muzzo.Main.Repositories;

namespace Muzzo.Main
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