using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Database.Models
{
    public class User
    {
        [Range(1, Int32.MaxValue)]
        public int Id { get; set;}
        [Required(ErrorMessage = "Enter first name, please!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter second name, please!")]
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your adress, please!")]
        public string Adress { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
