using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Business;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult DoLogin(Users u)
        {
            //LoginService ls = new LoginService();

            //UserStatus status = ls.GetUserValidity(u);

            Users user = db.Users.Find(u.UserName);

            bool rememberMe = false;

            if (user != null)
            {
                if (user.Password == u.Password)
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, rememberMe);
                    //Session["IsAdmin"] = IsAdmin;
                    return RedirectToAction("Index", "Employees");
                }
            }
            ModelState.AddModelError("CredentialError", "账号或密码不正确");
            return View("Login");
        }
    }
}