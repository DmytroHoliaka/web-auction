namespace WebAuction.Backend.RequestViews
{
    public class AuctionView
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CreatorId { get; set; }
        public List<byte[]>? Images { get; set; }
    }
}
