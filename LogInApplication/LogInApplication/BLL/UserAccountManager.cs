using LogInApplication.Models;
using LogInApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogInApplication.BLL
{
    public class UserAccountManager
    {
        UserAccountRepository _userAccountRepository = new UserAccountRepository();

        public bool Add(UserAccount userAccount)
        {
            return _userAccountRepository.Add(userAccount);
        }

        public List<UserAccount> GetAll()
        {
            return _userAccountRepository.GetAll();
        }
    }
}