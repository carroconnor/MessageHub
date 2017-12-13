using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageHub.Models;
using MessageHub.ViewModels;

namespace MessageHub.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Messages
        public ActionResult Create()
        {

            var viewModel = new MessageFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}