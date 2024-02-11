namespace WebAuction.Backend.Database.Views
{
    public class BidRequest
    {
        public decimal Bid { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid AuctionId { get; set; }
    }
}