using Muzzo.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.GigId, a.AttendeeId });
            
        }
    }
}