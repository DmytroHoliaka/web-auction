using Microsoft.AspNetCore.Mvc;
using WebAuction.Backend.Database.Management;
using WebAuction.Backend.Validators;

namespace WebAuction.Backend.Controllers
{
    [Route("Account")]
    public class SignInController : Controller
    {
        private readonly FormValidator _fv;
        private readonly DatabaseManager _dm;

        public SignInController(FormValidator fv, DatabaseManager dm)
        {
            _fv = fv;
            _dm = dm;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUser(IFormCollection form)
        {
            string error = await _fv.GetSignInFormError(form);

            if (error != string.Empty)
            {
                return Json(new { success = false, message = error });
            }

            Guid userId = await _dm.GetUserId(form["email"]!);

            Response.Cookies.Append("userStatus", "user");
            Response.Cookies.Append("userId", userId.ToString());
            return Json(new { success = true, redirectUrl = form["returnUrl"] });
        }
    }
}
