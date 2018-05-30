using System.Collections.Generic;

namespace Database.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter organization name, please!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter organization code, please!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Enter organization type, please!")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Choose one of the options")]
        public bool GeneralPartnership { get; set; }
        public bool LimitedPartnership { get; set; }
        public bool LimitedLiabilityCompany { get; set; }
        public bool IncorporatedCompany { get; set; }
        public bool Owner { get; set; }
        [Required(ErrorMessage = "Enter any other information, please!")]
        public string Other { get; set; }

        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
        public List<Country> Countries { set; get; }
    }
}
