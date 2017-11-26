using Muzzo.Core.Models;
using System.Collections.Generic;

namespace Muzzo.Core.Repositories
{
    public interface IAttendanceRepository
    {
        void AddAttendance(Attendance attendance);
        void RemoveAttendance(Attendance attendance);
        IEnumerable<Attendance> GetFutureUserAttendances(string attendeeId);
        Attendance GetAttendance(int gigId, string attendeeId);
       
    }
}