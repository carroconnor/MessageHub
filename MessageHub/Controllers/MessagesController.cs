using System.Data.Entity;
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

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var messages = _context.Messages
                .Where(g => g.ArtistId == userId)
                .Include(g => g.Genre)
                .ToList();

            return View(messages);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var message = _context.Messages.FirstOrDefault(g => g.Id == id && g.ArtistId == userId);

            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }

            return RedirectToAction("Mine", "Messages");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var message = _context.Messages.FirstOrDefault(g => g.Id == id && g.ArtistId == userId);

            var viewModel = new MessageFormViewModel
            {
                Heading = "Edit a Message",
                Id = message.Id,
                Genres = _context.Genres.ToList(),
                Date = message.DateTime.ToString("d MMM yyyy"),
                Time = message.DateTime.ToString("HH mm"),
                Genre = message.GenreId,
                Message = message.Venue
            };

            return View("MessageForm", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MessageFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Heading = "Add a Message"
            };

            return View("MessageForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("MessageForm", viewModel);
            }

            var message = new Message
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Message
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Messages");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MessageFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("MessageForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var message = _context.Messages.FirstOrDefault(g => g.Id == viewModel.Id && g.ArtistId == userId);
            message.Venue = viewModel.Message;
            message.DateTime = viewModel.GetDateTime();
            message.GenreId = viewModel.Genre;


            _context.SaveChanges();

            return RedirectToAction("Mine", "Messages");
        }
    }
}