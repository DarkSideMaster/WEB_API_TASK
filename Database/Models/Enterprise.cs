using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Enterprise name, please!")]
        public string Name { get; set; }

        public List<Organization> Organizations { set; get; }
    }
}
