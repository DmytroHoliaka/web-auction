using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using WebAuction.Backend.Database.Management;
using WebAuction.Backend.RequestViews;

namespace WebAuction.Backend.Controllers
{
    [Route("Auction")]
    public class AuctionController : Controller
    {
        private readonly DatabaseManager _dm;

        public AuctionController(DatabaseManager dm)
        {
            _dm = dm;
        }

        [HttpGet("/create_auction.html")]
        public async Task<IActionResult> ReachPage()
        {
            if (Request.Cookies["userStatus"] != "user")
            {
                return Redirect("/sign_in.html?returnUrl=/create_auction.html");
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Frontend", "create_auction.html");
            string content = await System.IO.File.ReadAllTextAsync(filePath);
            return Content(content, "text/html; charset=utf-8");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAuction([FromBody] AuctionView auction)
        {
            await _dm.InsertAuctionAsync(auction.Name,
                                         auction.Description,
                                         auction.StartPrice,
                                         auction.StartDate,
                                         auction.EndDate,
                                         auction.CreatorId);

            return Ok();
        }
    }
}
