namespace WebAuction.Backend.Database.Views
{
    public class AuctionSummaryDTO
    {
        public string? Base64Image { get; set; }
        public string? ListingTitle { get; set; }
        public decimal StartingBid { get; set; }
        public decimal CurrentBid { get; set; }
        public DateTime AuctionEnds { get; set; }
        public Guid AuctionId { get; set; }
    }
}
