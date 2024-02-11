namespace WebAuction.Backend.Database.Views
{
    public class AuctionSummary
    {
        public byte[]? ImageData { get; set; }
        public string? ListingTitle { get; set; }
        public decimal StartingBid { get; set; }
        public decimal? CurrentBid { get; set; }
        public DateTime AuctionEnds { get; set; }
        public Guid AuctionId { get; set; }

        public string? Base64Image
        {
            get { return ImageData != null ? Convert.ToBase64String(ImageData) : null; }
        }
    }
}
