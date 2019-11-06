using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NauAn.Models;
using NauAn.Models.Entities;

namespace NauAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBNAContext _context;
        public HomeController(DBNAContext context)
        {
            _context = context;
        }
        public IActionResult LiveStream()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Thông Tin Về Chúng Tôi!.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
        [Route("Register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if( account != null ){
                    ViewBag.Message = " Tài khoản đã tồn tại Vui lòng chọn tên đăng nhập khác !" ;
                    return View();
                }
                else
                {
                    _context.Users.Add(new User
                    {
                        UserName = user.UserName,
                        Password = user.Password,
                        Role = "user"
                    });

                    _context.SaveChangesAsync();
                    ModelState.Clear();
                    ViewBag.Message = "Bạn đã đăng ký thành công tài khoản " + user.UserName + "\n Đăng Nhập ngay nào!";
                    return View("Login");
                }
                
            }
            ViewBag.Message = null;
            return View();
        }
        [Route("Login")]
        public ActionResult Login()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(User user)
        {
            var account = _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();

            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.ID.ToString()); 
                HttpContext.Session.SetString("UserName", account.UserName);
                HttpContext.Session.SetString("Role", account.Role);
                return RedirectToAction("Index", "Posts");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
            }

            return View();
        }

        [Route("Logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Posts");
        }
    }
}
