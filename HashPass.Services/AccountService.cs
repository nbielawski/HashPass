using HashPass.Data;
using HashPass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPass.Services
{
    public class AccountService
    {
        private readonly Guid _userId;

        public AccountService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAccount(AccountCreate model)
        {
            var entity =
                 new Account()
                 {
                     OwnerId = _userId,
                     AcctName = model.AcctName,
                     AcctPassword = model.AcctPassword,
                     AddedUtc = DateTimeOffset.Now
                 };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Accounts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AccountListItem> GetAccount()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Accounts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AccountListItem
                                {
                                    AccountId = e.AccountId,
                                    AcctName = e.AcctName,
                                    AcctPassword = e.AcctPassword,
                                    AddedUtc = e.AddedUtc
                                }
                               );

                return query.ToArray();
                
            }
        }



    }
}
