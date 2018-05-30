using System.Collections.Generic;

namespace Database.Models
{
    public class Family
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter family name, please!")]
        public string Name { get; set; }
        public int BuisnessId { get; set; }
        public Business Business { get; set; }

        public List<Offering> Offerings { get; set; }
    }
}
