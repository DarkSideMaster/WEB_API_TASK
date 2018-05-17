using System.Collections.Generic;

namespace Database.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Family> Families { get; set; }
    }
}
