using DbFirstApproach.Data;
using DbFirstApproach.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DbFirstApproach.Controllers
{
    public class AuthController : Controller
    {
        private readonly EcommerecedotnetcoreContext db;
        public AuthController(EcommerecedotnetcoreContext db)
        {
            this.db = db;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User u)
        {
            u.Role = "User";
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("SignIn");

        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Login log)
        {
            var data = db.Users.Where(x=>x.Email.Equals(log.Email)).SingleOrDefault();
            if(data != null)
            {
                bool v=data.Email.Equals(log.Email) && data.Password.Equals(log.Password);
                if(v)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, log.Email) },
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                    HttpContext.Session.SetString("uemail", log.Email);
                    return RedirectToAction("Home", "Dashboard");

                }
                else
                {
                    TempData["errorpasword"] = "Invalid Password";
                }
            }
            else
            {
                TempData["erroremail"] = "Invalid Email";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedcookies = Request.Cookies.Keys;
            foreach (var cookie in storedcookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("SignIn");
        }

    }
}
