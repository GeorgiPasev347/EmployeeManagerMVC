using System.ComponentModel.DataAnnotations;

namespace SampleCrudMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "FisrtName must be between 2 to 50 symbols.")]
        public string? FirstName { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "MiddleName must be between 2 to 50 symbols.")]
        public string? MiddleName { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "LastName must be between 2 to 50 symbols.")]
        public string? LastName { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 symbols")]
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? EmailAdress { get; set; }
        public string? Gender { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Country must be at least 2 characters long.")]
        public string? Country { get; set; }
     
    }
}
