using System.Collections.Generic;

namespace Database.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public bool GeneralPartnership { get; set; }
        public bool LimitedPartnership { get; set; }
        public bool LimitedLiabilityCompany { get; set; }
        public bool IncorporatedCompany { get; set; }
        public bool Owner { get; set; }
        public string Other { get; set; }

        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
        public List<Country> Countries { set; get; }
    }
}
