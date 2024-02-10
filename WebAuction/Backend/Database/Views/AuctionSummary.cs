namespace WebAuction.Backend.Database.Views
{
    public class AuctionSummary
    {
        public string? ListingTitle { get; set; }
        public decimal StartingBid { get; set; }
        public decimal CurrentBid { get; set; }
        public DateTime AuctionEnds { get; set; }
    }
}
