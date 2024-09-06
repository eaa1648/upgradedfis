public class Department
{
    public long Id { get; set; }
    public string Name { get; set; }

    public ICollection<Employee> Employees { get; set; }
    public ICollection<Admin> Admins { get; set; }
}
