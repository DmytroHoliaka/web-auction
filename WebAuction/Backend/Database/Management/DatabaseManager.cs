using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Database.Entities;
using WebAuction.Backend.Database.Views;

namespace WebAuction.Backend.Database.Management
{
    // ToDo: Make interface implementation
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

        public async Task<List<AuctionHistory>> GetAuctionHistory(Guid AuctionId)
        {
            SqlParameter sqlParameter = new("@AuctionId", AuctionId);

            List<AuctionHistory> history = await _db.Set<AuctionHistory>()
                .FromSqlRaw("SELECT * FROM GetAuctionHistory(@AuctionId)", sqlParameter)
                .ToListAsync();

            return history;
        }
    }
}
