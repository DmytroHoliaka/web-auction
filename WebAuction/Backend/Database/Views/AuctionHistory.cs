namespace WebAuction.Backend.Database.Views
{
    public class AuctionHistory
    {
        public string? Username { get; set; }
        public decimal Bid { get; set; }
        public DateTime Date { get; set; }
        
        public Guid BetId { get; set; }
    }
}
