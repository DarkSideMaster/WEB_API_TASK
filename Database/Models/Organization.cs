using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Organization
    {
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter organization name, please!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter organization code, please!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Enter organization type, please!")]
        public string Type { get; set; }
        public bool GeneralPartnership { get; set; }
        public bool LimitedPartnership { get; set; }
        public bool LimitedLiabilityCompany { get; set; }
        public bool IncorporatedCompany { get; set; }
        [Required(ErrorMessage = "Enter owner of the organization (first name and second name), please!")]
        public string Owner { get; set; }
        public string Other { get; set; }
        public int EnterpriseId { get; set; }

        public Enterprise Enterprise { get; set; }
        public List<Country> Countries { set; get; }
    }
}
