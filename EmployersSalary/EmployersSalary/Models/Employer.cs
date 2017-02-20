using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployersSalary.Models
{
    public class Employer
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(225)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(225)]
        [Display(Name = "Last Name")]
        [Key]
        [Column(Order = 2)]
        public string LastName { get; set; }
        [Display(Name = "Net Salary")]
        public float? NetSalary { get; set; }
    }
}