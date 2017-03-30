using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstPractice
{
    [Table("Customers")]
    public class CustomerDTO
    {
        [Key]
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }

        //Parent Entity should have 'virtual' collection of child objects
        public virtual ICollection<CustAccountsDTO> Accounts { get; set; }
    }
}
