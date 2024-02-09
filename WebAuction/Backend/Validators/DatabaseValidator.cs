using Microsoft.EntityFrameworkCore;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Database.Entities;

namespace WebAuction.Backend.Validators
{
    public class DatabaseValidator
    {
        private readonly ApplicationContext _db;

        public DatabaseValidator(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> IsEmailExists(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            User? user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            
            return user is not null;
        }

        public async Task<bool> IsUsernameExists(string? username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            User? user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            return user is not null;
        }

        public async Task<bool> IsPasswordSuitable(string email, string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            User user = await _db.Users.FirstAsync(u => u.Email == email);
            return user.Password == password;
        }
    }
}
