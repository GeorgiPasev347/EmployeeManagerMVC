namespace SampleCrudMVC.Models
{
    public class EmployeeSearchVM
    {
        public string? Name { get; set; }    
            public string? Position { get; set; }
        public List<Employee> Results { get; set; }
    }
}
