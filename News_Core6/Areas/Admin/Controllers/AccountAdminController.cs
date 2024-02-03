using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News_Core6.Areas.Admin.Data;
using News_Core6.Extension;
using News_Core6.Helpper;
using News_Core6.Models;
using System.Security.Claims;

namespace News_Core6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountAdminController : Controller
    {
        private readonly AppDbContext _context;



        public AccountAdminController(AppDbContext context)
        {
            _context = context;

        }


        // login admin


        [AllowAnonymous]
        [Route("dang-nhap-admin.html", Name = "Loginadmin")]

        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("AccountId");
            if (taikhoanID != null)
            {



                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap-admin.html", Name = "Loginadmin")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (model.Password.Length <= 5)
            {
                ViewBag.Error = "Mật khẩu phải hơn 6 ký tự";
                return View();
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    Account kh = _context.Accounts.Include(a => a.Role).SingleOrDefault(a => a.Email.ToLower() == model.Email.ToLower().Trim());

                    if (kh == null)
                    {
                        ViewBag.Error = "Tài khoản không tồn tại";
                        return View();
                    }
                    string pass = (model.Password.Trim()).ToMD5();

                    if (kh.Password.Trim() != pass)
                    {
                        ViewBag.Error = "Sai mật khâu";
                        return View();
                    }


                    if (kh.RoleId == 1)
                    {
                        //dang nhap thanh cong

                        //ghi nhan tg dang nhap
                        kh.LastLogin = DateTime.Now;
                        _context.Update(kh);
                        await _context.SaveChangesAsync();

                        var taikhoan = HttpContext.Session.GetString("AccountId");

                        //identity

                        //luu session makh

                        HttpContext.Session.SetString("AccountId", kh.Id.ToString());

                        //edentity

                        var userClaims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Name, kh.FullName),
                        new Claim(ClaimTypes.Email, kh.Email),
                        new Claim("AccountId", kh.Id.ToString()),
                        new Claim("RoleId", kh.RoleId.ToString()),
                        new Claim(ClaimTypes.Role, kh.Role.RoleName)


                    };

                        var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                        var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                        await HttpContext.SignInAsync(userPrincipal);



                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Tài khoản không tồn tại";
                        return View();
                    }



                }
            }
            catch
            {
                return RedirectToAction("Login", "AccountAdmin");
            }

            return RedirectToAction("Login", "AccountAdmin");




        }


        //logout

        [Route("logout-admin.html", Name = "Logoutadmin")]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Remove("AccountId");
                return RedirectToAction("Login", "AccountAdmin");
            }
            catch
            {
                return RedirectToAction("Login", "AccountAdmin");
            }
        }


    }
}
