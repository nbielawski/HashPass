using HashPass.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HashPass.Web.Tests.Controllers.PassswordControllerTests
{
    [TestClass]
    public class CreatePost : PasswordControllerTestBase
    {
        private ActionResult Act()
        {
            return Controller.Create(new AccountCreate());
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            var result = Act();

            Assert.AreEqual(1, Svc.CreateAccountCallCount);
        }

    }
}