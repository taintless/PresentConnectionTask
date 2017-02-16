using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployersSalary.Models
{
    public class Employer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Display(Name = "Net Salary")]
        public float NetSalary { get; set; }
    }
}