using HashPass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Contracts
{
    public interface IAccountService
    {
        bool CreateAccount(AccountCreate model);
        IEnumerable<AccountListItem> GetAccount();
        AccountDetail GetAccountById(int AccountId);
        bool UpdateAccount(AccountEdit model);
        bool DeleteAccount(int acctId);
    }
}
