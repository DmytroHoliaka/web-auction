using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Database.Views;

namespace WebAuction.Backend.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ApplicationContext _db;

        public HomeController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetMainPage()
        {
            return Redirect("/index.html");
        }

        [HttpGet("Data/AuctionSummaries")]
        public async Task<IActionResult> GetAllAuctions()
        {
            List<AuctionSummaryDTO> auctions = await _db.AuctionSummaries.Select(auction =>
                new AuctionSummaryDTO()
                {
                    Base64Image = auction.Base64Image,
                    ListingTitle = auction.ListingTitle,
                    StartingBid = auction.StartingBid,
                    CurrentBid = auction.CurrentBid,
                    AuctionEnds = auction.AuctionEnds,
                    AuctionId = auction.AuctionId,
                }).ToListAsync();

            return Json(auctions);
        }
    }
}
