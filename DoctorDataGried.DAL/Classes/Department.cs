using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoctorDataGried.DAL.Classes
{
    [Table("tblDepartments")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255), Required]
        public string Name { get; set; }
        [Required]
        public int CabinetNumber { get; set; }
    }
}
