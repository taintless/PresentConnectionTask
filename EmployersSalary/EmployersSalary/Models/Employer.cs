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
        //public int Id { get; set; }
        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        [Key]
        [Column(Order = 2)]
        public string LastName { get; set; }
        [Display(Name = "Net Salary")]
        public float? NetSalary { get; set; }

        //public string Title
        //{
        //    get
        //    {
        //        return Id != 0 ? "Edit Employer" : "New Employer";
        //    }
        //}
        //public Employer()
        //{
        //    Id = 0;
        //}
    }
}