namespace WebApplication2.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } //Primary Key
        public string Name { get; set; } = string.Empty;

        //Relationship with Employee
        public ICollection<Employee> Employees { get; set; } //Collection Navigatiio
    }
}
