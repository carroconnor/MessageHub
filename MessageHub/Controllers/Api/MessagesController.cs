using System.Linq;
using System.Web.Http;
using MessageHub.Models;
using Microsoft.AspNet.Identity;

namespace MessageHub.Controllers.Api
{
    [Authorize]
    public class MessagesController : ApiController
    {
        private ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var message = _context.Messages.Single(g => g.Id == id && g.ArtistId == userId);
            message.IsCanceled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
