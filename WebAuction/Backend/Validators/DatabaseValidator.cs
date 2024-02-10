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

        public async Task<bool> IsEmailExists(string email)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user is not null;
        }

        public async Task<bool> IsUsernameExists(string username)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user is not null;
        }

        public async Task<string> GetUserSignInError(string email, string password)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            
            if (user is null)
            {
                return "Such email doesn't exists";
            }

            if (user.Password != password)
            {
                return "Password is incorrect";
            }

            return string.Empty;
        }
    }
}
