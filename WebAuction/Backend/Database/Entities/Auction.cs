namespace WebAuction.Backend.Database.Entities
{
    public class Auction
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal StartPrice { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid CreatorId { get; set; }
        public User? Creator { get; set; }

        public ICollection<Bet>? Bets { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
