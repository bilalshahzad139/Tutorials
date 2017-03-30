using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst_WO_Database
{
    [Table("Customer")]
    public class CustomerDTO
    {
        [Key]
        public int CustomerID { get; set; }
        public String Name { get; set; }
    }
}
