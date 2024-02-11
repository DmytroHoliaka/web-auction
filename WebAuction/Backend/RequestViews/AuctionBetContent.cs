namespace WebAuction.Backend.Database.Views
{
    public class AuctionBetContent
    {
        public string? Title { get; set; }
        public decimal StartBet { get; set; }
        public DateTime Deadline { get; set; }
        public string? Description { get; set; }
        public byte[]? MainImage { get; set; }
        public List<byte[]>? Images { get; set; }
    }
}
