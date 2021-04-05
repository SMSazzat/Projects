using LogInApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LogInApplication.DatabaseContext
{
    public class UserDb:DbContext
    {
        public DbSet<UserAccount> userAccounts { get; set; }
    }
}