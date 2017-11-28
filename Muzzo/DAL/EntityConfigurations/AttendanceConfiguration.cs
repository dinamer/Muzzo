using Muzzo.Main.Models;
using System.Data.Entity.ModelConfiguration;

namespace Muzzo.DAL.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.GigId, a.AttendeeId });
            
        }
    }
}