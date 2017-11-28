using Muzzo.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.DAL.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {

        public NotificationConfiguration()
        {
            HasRequired(n => n.Gig).WithMany().HasForeignKey(n => n.GigId);
      
        }
    }
}