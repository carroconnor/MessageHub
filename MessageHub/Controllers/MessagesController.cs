using System;
using System.Linq;
using System.Web.Mvc;
using MessageHub.Models;
using MessageHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace MessageHub.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Messages
        [Authorize]
        public ActionResult Create()
        {

            var viewModel = new MessageFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(MessageFormViewModel viewModel)
        {
            var message = new Message
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Message
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}