using Microsoft.AspNetCore.Mvc;
using WebAuction.Backend.Database.Management;
using WebAuction.Backend.Database.Views;

namespace WebAuction.Backend.Controllers
{
    [Route("Bet")]
    public class BetController : Controller
    {
        private readonly DatabaseManager _dm;

        public BetController(DatabaseManager dm)
        {
            _dm = dm;
        }

        [HttpGet("Content")]
        public async Task<IActionResult> GetAuctionDetails()
        {
            string userStatus = Request.Cookies["userStatus"]!;

            if (userStatus == "guest")
            {
                return Json(new { redirectToSignIn = true });
            }

            string? auctionIdStr = Request.Query["auctionId"];

            if (auctionIdStr is null)
            {
                return BadRequest("Query string 'auctionId' is missing or empty.");
            }

            if (Guid.TryParse(auctionIdStr, out Guid auctionId) == false)
            {
                return BadRequest("Query string 'auctionId' is invalid.");
            }

            List<AuctionHistory> history = await _dm.GetAuctionHistory(auctionId);
            AuctionBetContent auctionContent = await _dm.GetAuctionBetContent(auctionId);

            var auctionDetails = new
            {
                Title = auctionContent.Title,
                StartBet = auctionContent.StartBet,
                Deadline = auctionContent.Deadline,
                Description = auctionContent.Description,
                MainImage = auctionContent.MainImage,
                Images = auctionContent.Images,
                History = history,
            };

            return Json(auctionDetails);
        }

        [HttpPost("Form")]
        public async Task<IActionResult> MakeBet([FromBody] BidRequest bidRequest)
        {
            string error = _dm.GetBidValueError(bidRequest.Bid, bidRequest.AuctionId);
            
            if (error != string.Empty)
            {
                return Content(error);
            }

            await _dm.CreateBetAsync(bidRequest.Bid, bidRequest.Date, 
                                     bidRequest.UserId, bidRequest.AuctionId);

            return Content("Your bet was successfully added");
        }
    }
}
