using HashPass.Contracts;
using HashPass.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Web.Tests.Controllers.PassswordControllerTests
{

    [TestClass]
    public abstract class PasswordControllerTestBase
    {
        protected FakeAccountService Svc;
        protected PasswordController Controller;


        [TestInitialize]
        public virtual void Arrange()
        {
            Svc = new FakeAccountService();
            Controller = new PasswordController(
                new Lazy<IAccountService>(() => Svc));
        }

    }
}