using Muzzo.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(un => new { un.UserId, un.NotificationId });
        }
    }
}