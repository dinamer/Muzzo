using Microsoft.AspNet.Identity;
using Muzzo.Dtos;
using Muzzo.Models;
using System.Linq;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;


        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            string userId = User.Identity.GetUserId();

            if (_dbContext.Attendees.Any(a => a.AttendeeId == userId && a.GigId == attendanceDto.GigId))
                return BadRequest("The attendee is already added.");
            Attendance attendance = new Attendance {

                GigId = attendanceDto.GigId,
                AttendeeId = userId

            };

            _dbContext.Attendees.Add(attendance);
            _dbContext.SaveChanges();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            string attendeeId = User.Identity.GetUserId();

            var attendance = _dbContext.Attendees
                             .SingleOrDefault(a => a.GigId == id && a.AttendeeId == attendeeId);

            if (attendance == null)
                return NotFound();

            _dbContext.Attendees.Remove(attendance);
            _dbContext.SaveChanges();

            return Ok(id);
        }
    }
}
