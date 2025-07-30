using PawnShop.App.Common.Enums;

namespace PawnShop.App.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal SuggestedPrice { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.WaitingForApproval;
        public string Condition { get; set; } // نو، کارکرده و...

        public Guid? ConsignmentId { get; set; }
        public Consignment Consignment { get; set; }

        public bool IsSold { get; set; } = false;

        public ICollection<ProductImage> Images { get; set; }
    }
}
