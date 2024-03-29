﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_Core6.DI.User.Home;
using News_Core6.Models;
using News_Core6.ModelViews;
using PagedList.Core;
using System.Diagnostics;

namespace News_Core6.Controllers
{
   


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        private readonly IHomeRepository _homeRepository;

       
        public HomeController(ILogger<HomeController> logger, AppDbContext context, IHomeRepository homeRepository)
        {
            _logger = logger;
            _context = context;
            _homeRepository = homeRepository;
        }

        //[ResponseCache(Duration = 60)]
        [AllowAnonymous] 
        public IActionResult Index(int? page)
        {
            var taikhoan = HttpContext.Session.GetString("AccountId");

            var smg = "";

            if(taikhoan != null)
            {
                smg = "co tai khoan";
                ViewBag.smg = smg;

            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 4;

            PagedList<PostViewModel> models = new PagedList<PostViewModel>(_homeRepository.PageListHome(),pageNumber, pageSize);



            var ListPost = _homeRepository.ListPostHome();

            ViewBag.ListNew = _homeRepository.ListNewHome();

            ViewBag.OnlyOnePost = _homeRepository.OnlyOnePost();

            //goi y tim kiem
            ViewBag.ListPostSearch = _context.Posts.ToList();

            return View(models);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}