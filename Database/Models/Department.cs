using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Department
    {
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter department name, please!")]
        public string Name { get; set; }
        public int OfferingId { get; set; }

        public Offering Offering { get; set; }
        public List<User> Users { set; get; }   
    }
}
