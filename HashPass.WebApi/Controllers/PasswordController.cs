using HashPass.Models;
using HashPass.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HashPass.API.Controllers
{
    [Authorize]
    public class PasswordController : ApiController
    {
        public IHttpActionResult GetAllAccounts()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new AccountService(userId);
            var accts = svc.GetAccount();
            return Ok(accts);
        }


        public IHttpActionResult Get(int id)
        {
            var acctService = new AccountService(Guid.Parse(User.Identity.GetUserId()));

            var acct = acctService.GetAccountById(id);

            if (acct == null) return NotFound();

            return Ok(acct);

        }


        public IHttpActionResult Post(AccountCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var acctService = new AccountService(Guid.Parse(User.Identity.GetUserId()));
            return Ok(acctService.CreateAccount(model));
        }


        public IHttpActionResult Put(AccountEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Make sure the note exists.
            var acctService = new AccountService(Guid.Parse(User.Identity.GetUserId()));
            var temp = acctService.GetAccountById(model.AccountId);
            if (temp == null) return NotFound();

            // Attempt to update.
            return Ok(acctService.UpdateAccount(model));
        }


        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var acctService = new AccountService(Guid.Parse(User.Identity.GetUserId()));
            var temp = acctService.GetAccountById(id);
            if (temp == null) return NotFound();

            return Ok(acctService.DeleteAccount(id));
        }
    }
}
