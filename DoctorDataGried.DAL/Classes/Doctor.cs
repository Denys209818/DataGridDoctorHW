using DoctorDataGried.DAL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoctorDataGried.DAL
{
    [Table("tblDoctors")]
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string FirstName { get; set; }
        [Required, StringLength(255)]
        public string LastName { get; set; }

        [ForeignKey("Department.Id")]
        public int DepartmentId { get; set; }
        [Required, StringLength(255)]
        public string Login { get; set; }
        [Required, StringLength(260)]
        public string Password { get; set; }

        public Department Department { get; set; }
        
    }
}
