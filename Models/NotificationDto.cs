// Models/NotificationDto.cs
namespace upgradedfis.Models
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public long WorkId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public long EmployeeId { get; set; }
    }
}
