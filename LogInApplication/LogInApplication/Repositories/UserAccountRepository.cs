using LogInApplication.DatabaseContext;
using LogInApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogInApplication.Repositories
{
    public class UserAccountRepository
    {
        UserDb _userDb = new UserDb();
        public bool Add(UserAccount userAccount)
        {
            int isExecuted = 0;

            _userDb.userAccounts.Add(userAccount);
            isExecuted = _userDb.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<UserAccount> GetAll()
            {
                 return _userDb.userAccounts.ToList();
            }
    }
    
}