using Microsoft.AspNetCore.Mvc;

namespace WebAuction.Backend.Controllers
{
    [Route("")]
    public class AuctionController : Controller
    {
        [HttpGet("create_auction.html")]
        public async Task<IActionResult> CreateAuction()
        {
            if (Request.Cookies["userStatus"] != "user")
            {
                return Redirect("/sign_in.html?returnUrl=/create_auction.html");
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Frontend", "create_auction.html");
            string content = await System.IO.File.ReadAllTextAsync(filePath);
            return Content(content, "text/html; charset=utf-8");
        }
    }
}
