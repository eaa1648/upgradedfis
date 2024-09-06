public class Comment
{
    public long Id { get; set; }
    public long WorkId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime MessageDate { get; set; }
    public bool IsSupport { get; set; }
    public long AdminId { get; set; }
    public long EmployeeId { get; set; }

    // Navigation Properties
    public Work Work { get; set; }
    public Admin Admin { get; set; }
    public Employee Employee { get; set; }
}
