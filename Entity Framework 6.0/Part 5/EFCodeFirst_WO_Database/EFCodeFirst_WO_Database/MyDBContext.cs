using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

namespace EFCodeFirst_WO_Database
{
    public class MyDBContext : DbContext
    {
        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<StudentDTO> Students { get; set; }
    }
}
