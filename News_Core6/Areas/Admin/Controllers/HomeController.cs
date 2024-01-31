using Microsoft.AspNetCore.Mvc;

namespace News_Core6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var demoSession = "day la session";


            HttpContext.Session.SetString("UserName", demoSession);

            return View();
        }

        [Route("/demosession")]

        public async Task<IActionResult> GetSession()
        {

            ViewBag.getSession = HttpContext.Session.GetString("UserName");
           
            return View();  
        }
    }
}
