public class Admin
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public long RoleId { get; set; }
    public long DepartmentId { get; set; }

    public Role Role { get; set; }
    public Department Department { get; set; }
}
