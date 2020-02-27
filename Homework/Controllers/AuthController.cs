using Homework.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            var model = new UserModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(userModel.Login=="admin"&& userModel.Password == "admin")
            {
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,"Admin"),
                        new Claim(ClaimTypes.Email,"admin@itstep.org"),
                        new Claim(ClaimTypes.Country,"Ukraine")
                },DefaultAuthenticationTypes.ApplicationCookie);
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(identity);

                return Redirect(GetUrl(userModel.ReturnUrl));
            }
            ModelState.AddModelError("", "Invalid login or password");
            return View();
        }
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("login");
        }

        private string GetUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                return Url.Action("index", "home");

            return returnUrl;
        }
    }
}