using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Family
    {
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter family name, please!")]
        public string Name { get; set; }
        public int BuisnessId { get; set; }

        public Business Business { get; set; }
        public List<Offering> Offerings { get; set; }
    }
}
