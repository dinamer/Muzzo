using Muzzo.Main.Models;
using Muzzo.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.DAL.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttendanceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAttendance(Attendance attendance)
        {
            _dbContext.Attendees.Add(attendance);
        }


        public void RemoveAttendance(Attendance attendance)
        {
            _dbContext.Attendees.Remove(attendance);
        }

        public IEnumerable<Attendance> GetFutureUserAttendances(string attendeeId)
        {
            return _dbContext.Attendees
                              .Where(a => a.AttendeeId == attendeeId && a.Gig.GigDateTime >= DateTime.Now)
                              .ToList();
        }

        public Attendance GetAttendance(int gigId, string attendeeId)
        {
            return _dbContext.Attendees.SingleOrDefault(a => a.AttendeeId == attendeeId && a.GigId == gigId);


        }



        
       
    }
}