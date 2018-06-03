using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Offering
    {
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter offering name, please!")]
        public string Name { get; set; }
        public int FamilyId { get; set; }

        public Family Family { get; set; }
        public List<Department> Departments { set; get; }
    }
}
