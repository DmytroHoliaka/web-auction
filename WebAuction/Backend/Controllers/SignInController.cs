using Microsoft.AspNetCore.Mvc;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Validators;

namespace WebAuction.Backend.Controllers
{
    [Route("Account")]
    public class SignInController : Controller
    {
        private readonly FormValidator _fv;

        public SignInController(FormValidator fv)
        {
            _fv = fv;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUser(IFormCollection form)
        {
            string error = await _fv.GetSignInFormError(form);

            if (error != string.Empty)
            {
                return Json(new { success = false, message = error });
            }

            Response.Cookies.Append("userStatus", "user");
            return Json(new { success = true, redirectUrl = form["returnUrl"] });
        }
    }
}
