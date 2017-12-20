using HashPass.Contracts;
using HashPass.Models;
using HashPass.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HashPass.Web.Controllers
{
    //#if !DEBUG
    //    [RequireHttps]
    //#endif
    [Authorize]
    public class PasswordController : Controller
    {
        private readonly Lazy<IAccountService> _acctService;

        public PasswordController()
        {
            _acctService = new Lazy<IAccountService>(() =>
           new AccountService(Guid.Parse(User.Identity.GetUserId())));
        }

        public PasswordController(Lazy<IAccountService> acctService)
        {
            _acctService = acctService;
        }

        // GET: Password

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

        public ActionResult Details(int id)
        {
            var svc = CreateAccountService();
            var model = svc.GetAccountById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {

            var svc = CreateAccountService();
            var detail = svc.GetAccountById(id);
            var model =
                new AccountEdit
                {
                    AccountId = detail.AccountId,
                    AcctName = detail.AcctName,
                    AcctPassword = detail.AcctPassword
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccountEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AccountId != id)
            {
                ModelState.AddModelError("", "ID does not match");
                return View(model);
            }

            var svc = CreateAccountService();
            if (svc.UpdateAccount(model))
            {
                TempData["SaveResult"] = "Your Account Has Been Updated";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Your Account Could Not Be Updated");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAccountService();
            var model = svc.GetAccountById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateAccountService();

            svc.DeleteAccount(id);

            TempData["SaveResult"] = "Account and Password were deleted.";

            return RedirectToAction("Index");
        }





    }
}