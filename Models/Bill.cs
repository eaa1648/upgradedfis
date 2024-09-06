public class Bill
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public DateTime BillDate { get; set; }
    public DateTime BillDateDue { get; set; }
    public double Amount { get; set; }
    public string Status { get; set; }
    public long PaymentMethodId { get; set; }

    public Company Company { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public ICollection<Tax> Taxes { get; set; }
}
