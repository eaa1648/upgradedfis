public class Company
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // İlişkiler
    public ICollection<Work> Works { get; set; } = new List<Work>(); // Works özelliği
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
