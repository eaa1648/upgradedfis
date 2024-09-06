public class EmployeeRole
{
    public long Id { get; set; }
    public string Name { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
