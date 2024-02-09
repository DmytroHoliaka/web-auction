namespace WebAuction.Backend.Database.Entities
{
    public class Bet
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; } 
        public DateTime Time { get; set; }

        public Guid UserId { get; set; }       
        public User? User { get; set; }

        public Guid AuctionId { get; set; }    
        public Auction? Auction { get; set; }
    }
}
