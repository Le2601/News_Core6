using Microsoft.AspNetCore.Mvc;
using News_Core6.Models;

namespace News_Core6.Controllers.Components
{
    public class MenuTopViewComponent : ViewComponent
    {

        private readonly AppDbContext _appDbContext;

        public MenuTopViewComponent (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
