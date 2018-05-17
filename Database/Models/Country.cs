using System.Collections.Generic;

namespace Database.Models
{

    public class Country
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public int Code { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public List<Business> Businesses { set; get; } 
    }

}
