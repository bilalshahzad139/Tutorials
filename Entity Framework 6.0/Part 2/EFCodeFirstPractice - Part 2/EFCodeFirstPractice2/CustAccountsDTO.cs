using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstPractice
{
    [Table("dbo.Customer_Accounts")]
    public class CustAccountsDTO
    {
        [Key]
        public int AccountID { get; set; }
        public String BankName { get; set; }
        public String AccountNumber { get; set; }
        public int CustomerID { get; set; }
        //This will be the object which is representing Customer record 
        //who is associated with this 'account'
        public virtual CustomerDTO Customer { get; set; }
    }
}
