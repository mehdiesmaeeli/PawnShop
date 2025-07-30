namespace PawnShop.App.Models
{
    public class Consignment
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public decimal? FinalPrice { get; set; }
        public float PlatformCommissionPercent { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpireAt { get; set; }

        public ConsignmentStatus Status { get; set; } = ConsignmentStatus.WaitingForApproval;

        public ICollection<Product> Products { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }

}
