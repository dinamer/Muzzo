using Muzzo.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.DAL.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(un => new { un.UserId, un.NotificationId });
        }
    }
}