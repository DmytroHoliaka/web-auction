using System.Text.Json.Serialization;
using System.Text.Json;

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
        public string? Images { get; set; }

        [JsonIgnore]
        public List<string>? ImagesList => string.IsNullOrEmpty(Images) ? null :
            JsonSerializer.Deserialize<List<string>>(Images);
    }
}
