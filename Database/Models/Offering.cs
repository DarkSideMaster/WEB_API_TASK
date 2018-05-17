using System.Collections.Generic;

namespace Database.Models
{
    public class Offering
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FamilyId { get; set; }
        public Family Family { get; set; }
        public List<Department> Departments { set; get; }
    }
}
