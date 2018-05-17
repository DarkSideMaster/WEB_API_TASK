using System.Collections.Generic;

namespace Database.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuisnessId { get; set; }
        public Business Business { get; set; }

        public List<Offering> Offerings { get; set; }
    }
}
