using Microsoft.AspNetCore.Mvc;
using WebAuction.Backend.Database.Management;
using WebAuction.Backend.Validators;

namespace WebAuction.Backend.Controllers
{
    [Route("Account")]
    public class RegisterController : Controller
    {
        private readonly DatabaseManager _dm;
        private readonly FormValidator _fv;

        public RegisterController(DatabaseManager dm, FormValidator fv)
        {
            _dm = dm;
            _fv = fv;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(IFormCollection form)
        {
            string error = await _fv.GetRegisterFormError(form);

            if (error != string.Empty)
            {
                return Json(new {success = false, message = error});
            }

            await _dm.InsertUserAsync(form["email"],
                                      form["username"],
                                      form["first_name"],
                                      form["last_name"],
                                      form["password"]);
            
            return Json(new { success = true, redirectUrl = "/" });
        }
    }
}
