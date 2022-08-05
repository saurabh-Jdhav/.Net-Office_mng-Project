using Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Office.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (officeEntities context = new officeEntities())
            {
                //database ke keywords
                bool IsValidUser = context.users.Any(user => user.username.ToLower() ==
                     model.UserName.ToLower() && user.password == model.UserPassword);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "employees");
                }

                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }

    }
}