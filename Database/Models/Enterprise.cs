using System.Collections.Generic;

namespace Database.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Organization> Organizations { set; get; }
    }
}