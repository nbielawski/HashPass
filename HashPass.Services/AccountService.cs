using HashPass.Contracts;
using HashPass.Data;
using HashPass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HashPass.Services
{
    public class AccountService : IAccountService
    {
        private readonly Guid _userId;

        
        public AccountService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAccount(AccountCreate model)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.AcctPassword);
            var entity =
                 new Account()
                 {
                     OwnerId = _userId,
                     AcctName = model.AcctName,
                     AcctPassword = hashedPassword,
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

        public AccountDetail GetAccountById(int AccountId)
        {
            
            
            using (var ctx = new ApplicationDbContext())
            {
            
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.AccountId == AccountId && e.OwnerId == _userId);


                return
                    new AccountDetail
                    {
                        AccountId = entity.AccountId,
                        AcctName = entity.AcctName,
                        AcctPassword = entity.AcctPassword,
                        AddedUtc = entity.AddedUtc,
                        UpdatedUtc = entity.UpdatedUtc
                    };


            }
        }

        public bool UpdateAccount(AccountEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accounts
                        .Single(e => e.AccountId == model.AccountId && e.OwnerId == _userId);

                entity.AcctName = model.AcctName;
                entity.AcctPassword = model.AcctPassword;
                entity.UpdatedUtc = DateTimeOffset.Now;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAccount(int acctId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity =
                    db
                    .Accounts
                    .Single(e => e.AccountId == acctId && e.OwnerId == _userId);

                db.Accounts.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }



        public bool VerifyPin(int pinNum)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = from u in db.Users
                            where u.PinNum == pinNum
                            select u;

                foreach (var u in query)
                {
                    return true;
                }

                return false;
            }
        }




    }
}
