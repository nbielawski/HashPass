using HashPass.Contracts;
using HashPass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Web.Tests.Controllers.PassswordControllerTests
{
    public class FakeAccountService : IAccountService
    {

        public int CreateAccountCallCount { get; private set; }

        public bool CreateAccountReturnValue { private get; set; } = true;


        public bool CreateAccount(AccountCreate model)
        {
            CreateAccountCallCount++;

            return CreateAccountReturnValue;
        }




        public bool DeleteAccount(int acctId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HashPass.Models.AccountListItem> GetAccount()
        {
            throw new NotImplementedException();
        }

        public HashPass.Models.AccountDetail GetAccountById(int AccountId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccount(HashPass.Models.AccountEdit model)
        {
            throw new NotImplementedException();
        }
    }
}