public class Notification
{
    public long Id { get; set; }
    public long WorkId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public long EmployeeId { get; set; }

    // İlişkiler
    public Work Work { get; set; }
    public Employee Employee { get; set; }
}
