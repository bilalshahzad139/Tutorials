using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

namespace EFCodeFirstPractice
{
    //This is like 'Database Manager'
    public class MyDBContext : DbContext
    {
        //This is like 'Table Manager'
        public DbSet<CustomerDTO> Customers
        {
            get;set;
        }
        public DbSet<CustAccountsDTO> Accounts { get; set; }
    }
}
