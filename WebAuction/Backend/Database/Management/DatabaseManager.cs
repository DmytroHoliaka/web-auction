using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Database.Entities;
using WebAuction.Backend.Database.Views;

namespace WebAuction.Backend.Database.Management
{
    public class DatabaseManager
    {
        private readonly ApplicationContext _db;

        public DatabaseManager(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Guid> InsertUserAsync(string? email,
                                                string? username,
                                                string? firstName,
                                                string? lastName,
                                                string? password)
        {
            User user = new()
            {
                Email = email,
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Password = password,
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<AuctionHistory>> GetAuctionHistory(Guid auctionId)
        {
            SqlParameter sqlParameter = new("@AuctionId", auctionId);

            List<AuctionHistory> history = await _db.Set<AuctionHistory>()
                .FromSqlRaw("SELECT * FROM GetAuctionHistory(@AuctionId)", sqlParameter)
                .ToListAsync();

            return history;
        }

        public async Task<AuctionBetContent> GetAuctionBetContent(Guid auctionId)
        {
            Auction auction = await _db.Auctions.FirstAsync(a => a.Id == auctionId);

            List<Image> images = await _db.Photos
                                            .Where(p => p.AuctionId == auction.Id)
                                            .ToListAsync();
            Image mainImage = images.First(i => i.IsMain == true);

            AuctionBetContent auctionContent = new()
            {
                Title = auction.Name,
                StartBet = auction.StartPrice,
                Deadline = auction.EndDate,
                Description = auction.Description,
                MainImage = mainImage.Data,
                Images = images.Select(i => i.Data).ToList()!,
            };

            return auctionContent;
        }

        public async Task<Guid> CreateBetAsync(decimal price, DateTime date, Guid userId, Guid auctionId)
        {
            Bet bet = new()
            {
                Price = price,
                Date = date,
                UserId = userId,
                AuctionId = auctionId,
            };

            await _db.Bets.AddAsync(bet);
            await _db.SaveChangesAsync();

            return bet.Id;
        }

        public async Task<Guid> GetUserId(string email)
        {
            User user = await _db.Users.FirstAsync(u => u.Email == email);
            return user.Id;
        }

        public string GetBidValueError(decimal betValue, Guid auctionId)
        {
            decimal maxValue = GetMaxBet(auctionId);

            return betValue > maxValue ? string.Empty : $"Minimum bet value is: {maxValue + 1}";
        }

        public decimal GetMaxBet(Guid auctionId)
        {
            bool hasBets = _db.Bets.Any(b => b.AuctionId == auctionId);

            if (hasBets == false)
            {
                return 0;
            }

            decimal maxPrice = _db.Bets
                                    .Where(b => b.AuctionId == auctionId)
                                    .Select(b => b.Price)
                                    .Max();
            return maxPrice;
        }

        public async Task<Guid> InsertAuctionAsync(string? name,
                                                   string? description,
                                                   decimal startPrice,
                                                   DateTime startDate,
                                                   DateTime endDate,
                                                   Guid creatorId)
        {
            Auction auction = new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                StartPrice = startPrice,
                StartDate = startDate,
                EndDate = endDate,
                CreatorId = creatorId,
            };

            await _db.Auctions.AddAsync(auction);
            await _db.SaveChangesAsync();

            return auction.Id;
        }
    }
}
