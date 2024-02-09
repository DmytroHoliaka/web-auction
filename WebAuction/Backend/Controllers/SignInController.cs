using Microsoft.AspNetCore.Mvc;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Validators;

namespace WebAuction.Backend.Controllers
{
    [Route("Account")]
    public class SignInController : Controller
    {
        private readonly DatabaseValidator _dv;

        public SignInController(DatabaseValidator dv)
        {
            _dv = dv;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUser(IFormCollection form)
        {
            if (await _dv.IsEmailExists(form["email"]) == false)
            {
                return Content("Email does not exist.");
            }
            
            if (await _dv.IsPasswordSuitable(form["email"]!, form["password"]) == false)
            {
                return Content("Password is incorrect.");
            }

            Response.Cookies.Append("userStatus", "user");

            return Ok("Welcome back!");
        }
    }
}
