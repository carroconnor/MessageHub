﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MessageHub.Models;
using MessageHub.ViewModels;

namespace MessageHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingMessages = _context.Messages
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now);

            var viewModel = new MessagesViewModel
            {
                UpcomingMessages = upcomingMessages,
                ShowActions = User.Identity.IsAuthenticated
            };


            return View(viewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}