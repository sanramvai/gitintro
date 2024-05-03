using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeTechManage.Models
{
    public class Employee
    {

        public int? Id { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Official Email ID")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public  string Email { get; set; }       
        public string Department { get; set; }
        public string PhotoPath { get; set; }
        
       
    }
}
