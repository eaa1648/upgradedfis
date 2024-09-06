public class PaymentMethod
{
    public long Id { get; set; }
    public string Name { get; set; }

    public ICollection<Bill> Bills { get; set; }
}
