﻿using System.Collections.Generic;

namespace Database.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter department name, please!")]
        public string Name { get; set; }
        public int OfferingId { get; set; }
        public Offering Offering { get; set; }

        public List<User> Users { set; get; }   
    }
}
