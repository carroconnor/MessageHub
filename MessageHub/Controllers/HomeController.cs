using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MessageHub.Models;

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
                .Where(g => g.DateTime > DateTime.Now);
            return View(upcomingMessages);
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