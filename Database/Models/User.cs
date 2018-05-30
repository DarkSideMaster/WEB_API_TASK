namespace Database.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter first name, please!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter second name, please!")]
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your adress, please!")]
        public string Adress { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
