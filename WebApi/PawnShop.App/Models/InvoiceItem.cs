namespace PawnShop.App.Models
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;

        public bool IsSettled { get; set; } = false;
    }

}
