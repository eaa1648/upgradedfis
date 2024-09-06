
namespace upgradedfis.Models
{
    public class PaymentMethodDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public List<BillDto> Bills { get; set; }
    }
}
