﻿namespace WebAuction.Backend.Database.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }  
        
        public ICollection<Auction>? CreatedAuctions { get; set; }
        public ICollection<Bet>? Bets { get; set; }
        public ICollection<Auction>? BetedAuctions { get; set; }
    }
}