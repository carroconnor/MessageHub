using System.Linq;
using System.Web.Http;
using MessageHub.Dtos;
using MessageHub.Models;
using Microsoft.AspNet.Identity;

namespace MessageHub.Controllers
{
    [Authorize]
    public class AttendancesApiController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesApiController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.MessageId == dto.MessageId
            ))
                return BadRequest("This already exists.");

            var attendance = new Attendance
            {
                MessageId = dto.MessageId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
