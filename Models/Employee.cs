namespace SampleCrudMVC.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; } 
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 symbols")]
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? EmailAdress { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? Position { get; internal set; }
    }
}
