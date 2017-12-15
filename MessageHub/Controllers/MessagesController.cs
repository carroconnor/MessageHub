﻿using System.Linq;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
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

            return RedirectToAction("Index", "Home");
        }
    }
}