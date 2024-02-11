using Microsoft.AspNetCore.Mvc;
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
            List<string> base64Data = auction.ImagesList!.Select(d => d.Substring(d.IndexOf(",") + 1)).ToList();

            List<byte[]> images = base64Data.Select(d => Convert.FromBase64String(d)).ToList();

            Guid auctionId = await _dm.InsertAuctionAsync(name: auction.Name,
                                         description: auction.Description,
                                         startPrice: auction.StartPrice,
                                         startDate: auction.StartDate,
                                         endDate: auction.EndDate,
                                         creatorId: auction.CreatorId);

            await _dm.InsertMainImage(images[0], auctionId);
            await _dm.InsertAdditionalImages(images.Skip(1).ToList(), auctionId);


            return Ok();
        }
    }
}
