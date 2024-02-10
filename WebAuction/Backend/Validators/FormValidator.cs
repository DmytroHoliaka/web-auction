namespace WebAuction.Backend.Validators
{
    public class FormValidator
    {
        private readonly DatabaseValidator _databaseValidator;
        private readonly DataValidator _dataValidator;

        public FormValidator(DatabaseValidator databaseValidator,
                             DataValidator dataValidator)
        {
            _databaseValidator = databaseValidator;
            _dataValidator = dataValidator;
        }

        public async Task<string> GetRegisterFormError(IFormCollection? form)
        {
            if (form is null)
            {
                return "Input instance is null";
            }

            if (_dataValidator.IsEmailValid(form["email"]) == false)
            {
                return "Incorrect email format";
            }
            
            if (_dataValidator.IsNameValid(form["username"]) == false)
            {
                return "Incorrect username";
            }
            
            if (_dataValidator.IsNameValid(form["first_name"]) == false)
            {
                return "Incorrect first name";
            }
            
            if (_dataValidator.IsNameValid(form["last_name"]) == false)
            {
                return "Incorrect last name";
            }
            
            if (_dataValidator.IsPasswordValid(form["password"]) == false)
            {
                return "Incorrect password";
            }

            if (await _databaseValidator.IsEmailExists(form["email"]!) == true)
            {
                return "Such email already exists";
            }

            if (await _databaseValidator.IsUsernameExists(form["username"]!) == true)
            {
                return "Such username already exists";
            }

            return string.Empty;
        }

        public async Task<string> GetSignInFormError(IFormCollection? form)
        {
            if (form is null)
            {
                return "Input instance is null";
            }

            if (_dataValidator.IsEmailValid(form["email"]) == false)
            {
                return "Incorrect email format";
            }

            if (_dataValidator.IsPasswordValid(form["password"]) == false)
            {
                return "Incorrect password format";
            }

            string error = await _databaseValidator.GetUserSignInError(form["email"]!, form["password"]!);

            return error;
        }
    }
}
