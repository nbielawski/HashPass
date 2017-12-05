using HashPass.Models;
using HashPass.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HashPass.Web.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password
        [Authorize]
        public ActionResult Index()
        {
            AccountService svc = NewMethod();
            var model = svc.GetAccount();

            return View(model);
        }

        private AccountService NewMethod()
        {
            AccountService svc = CreateAccountService();
            return svc;
        }

        private AccountService CreateAccountService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new AccountService(userId);
            return svc;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
            public ActionResult Create(AccountCreate model)
        {
            if (!ModelState.IsValid) return View(model);




            var svc = CreateAccountService();


            if (svc.CreateAccount(model))
            {
                TempData["SaveResult"] = "Your Account and Password have been safely stored.";
                return RedirectToAction("Index");
            };


            ModelState.AddModelError("", "Account/Password could not be saved.");
            return View(model);
        }
    }
}