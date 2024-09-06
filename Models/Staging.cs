using System.Collections.Generic;

public class Staging
{
    public long Id { get; set; } // Id türü `long` olarak güncellendi
    public long StageId { get; set; }
    public string Name { get; set; }

    // Navigation Properties
    public ICollection<Work> Works { get; set; } = new List<Work>();
}
