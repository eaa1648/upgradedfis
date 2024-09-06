public class Employee
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long CompanyId { get; set; }
    public long RoleId { get; set; }
    public long DepartmentId { get; set; }

    public Company Company { get; set; }
    public Role Role { get; set; }
    public Department Department { get; set; }
    public ICollection<Work> Works { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}
