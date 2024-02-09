namespace WebAuction.Backend.Database.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Data { get; set; }
        
        public Guid AuctionId { get; set; } 
        public Auction? Auction { get; set; }
    }
}
