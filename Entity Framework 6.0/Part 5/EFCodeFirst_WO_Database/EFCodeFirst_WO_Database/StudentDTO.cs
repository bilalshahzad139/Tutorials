using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EFCodeFirst_WO_Database
{
    [Table("Student")]
    public class StudentDTO
    {
        [Key]
        public int StudentID { get; set; }
        public String Name { get; set; }
    }
}
