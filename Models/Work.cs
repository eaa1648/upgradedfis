using System;
using System.Collections.Generic;

public class Work
{
    public long Id { get; set; } // Id türü `long`
    public string Status { get; set; }
    public string Title { get; set; }
    public double? Hours { get; set; }
    public long? EmployeeCount { get; set; }
    public string Desc { get; set; }
    public long? Price { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public string Priority { get; set; }
    public long StagingId { get; set; } // StagingId türü `long`
    public long EmployeeId { get; set; }
    public long CompanyId { get; set; }

    // Navigation Properties
    public Company Company { get; set; }
    public Employee Employee { get; set; }
    public Staging Staging { get; set; }
    
    // Add Comments navigation property
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
