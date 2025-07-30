using PawnShop.App.Common.Enums;

namespace PawnShop.App.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public string SellerId { get; set; }
        public ApplicationUser Seller { get; set; }


        public Guid InvoiceItemId { get; set; }
        public InvoiceItem InvoiceItem { get; set; }

        public decimal SellerAmount { get; set; }
        public decimal PlatformCommission { get; set; }

        public DateTime SettledAt { get; set; } = DateTime.UtcNow;
        public TransactionStatus Status { get; set; } = TransactionStatus.Completed;
    }

}
