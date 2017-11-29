using Muzzo.Main.Models;
using System.Collections.Generic;

namespace Muzzo.Main.Repositories
{
    public interface IAttendanceRepository
    {
        void AddAttendance(Attendance attendance);
        void RemoveAttendance(Attendance attendance);
        IEnumerable<Attendance> GetFutureUserAttendances(string attendeeId);
        Attendance GetAttendance(int gigId, string attendeeId);
       
    }
}