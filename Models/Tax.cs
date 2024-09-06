public class Tax
{
    public long Id { get; set; }
    public long BillId { get; set; }
    public string TaxType { get; set; }
    public double TaxRate { get; set; }
    public double TaxAmount { get; set; }
    public string Desc { get; set; }

    public Bill Bill { get; set; }
}
