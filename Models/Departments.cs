using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.ComponentModel.DataAnnotations;
namespace SampleCrudMVC.Models
{
    public class Departments
    {
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Department name is required")]
        public string Name { get; set; }

         public string Description { get; set; }   
    }
}
