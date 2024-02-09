using System.Text.RegularExpressions;

namespace WebAuction.Backend.Validators
{
    public class DataValidator
    {
        public bool IsNameValid(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            int nameMaxLength = 4;

            if (name.Length < nameMaxLength)
            {
                return false;
            }

            return true;
        }

        public bool IsPasswordValid(string? password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            int passwordMaxLength = 8;

            if (password.Length < passwordMaxLength)
            {
                return false;
            }

            return true;
        }

        public bool IsEmailValid(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string emailPattern = @"^[a-zA-Z0-9_]+@[a-zA-Z0-9_]+\.[a-zA-Z0-9_]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
