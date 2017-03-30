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

        [StringLength(maximumLength : 10)]
        public String Name { get; set; }

        [Required(ErrorMessage = "This is mandatory!")]
        public String Address { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public String TestColumn { get; set; }

        //Parent Entity should have 'virtual' collection of child objects
        public virtual ICollection<CustAccountsDTO> Accounts { get; set; }
    }
}
