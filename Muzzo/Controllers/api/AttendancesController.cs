using Microsoft.AspNet.Identity;
using Muzzo.Main;
using Muzzo.Main.Dtos;
using Muzzo.Main.Models;
using Muzzo.DAL;
using System.Web.Http;

namespace Muzzo.Controllers.api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        private ApplicationDbContext _dbContext;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbContext = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            string userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(attendanceDto.GigId, userId);

            if (attendance != null)
                return BadRequest("The attendee already added.");


            attendance = new Attendance
            {
                GigId = attendanceDto.GigId,
                AttendeeId = userId

            };


            _unitOfWork.Attendances.AddAttendance(attendance);

            _unitOfWork.Complete();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
           
            var attendance = _unitOfWork.Attendances.GetAttendance(id, User.Identity.GetUserId());
                
            if (attendance == null)
                return NotFound();

            _unitOfWork.Attendances.RemoveAttendance(attendance);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
