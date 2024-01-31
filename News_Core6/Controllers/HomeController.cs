using Microsoft.AspNetCore.Mvc;
using News_Core6.Models;
using System.Diagnostics;

namespace News_Core6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

       
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult Index()
        {
            var taikhoan = HttpContext.Session.GetString("AccountId");

            var smg = "";

            if(taikhoan != null)
            {
                smg = "co tai khoan";
                ViewBag.smg = smg;

            }
            


            var ListPost = _context.Posts.ToList();
            return View(ListPost);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}