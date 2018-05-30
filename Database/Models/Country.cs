using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{

    public class Country
    {
        public int Id { get; set; }  
        [Required(ErrorMessage = "Enter country name, please!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter country code, please!")]
        public int Code { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public List<Business> Businesses { set; get; } 
    }

}
