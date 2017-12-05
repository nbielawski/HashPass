using HashPass.Models;
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
            var model = new AccountListItem [0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
            public ActionResult Create(AccountCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}