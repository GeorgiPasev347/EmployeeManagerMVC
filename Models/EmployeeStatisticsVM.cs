namespace SampleCrudMVC.Models
{
    public class EmployeeStatisticsVM
    {
        public int TotalEmployees { get; set; }
        public int MaleEmployees { get; set; }
        public int FemaleEmployees { get; set; }
        public string TopCountry { get; set; }
        public double AverageSalary { get; set; }
    }
}
