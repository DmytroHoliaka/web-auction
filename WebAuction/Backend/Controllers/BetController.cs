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

        [HttpGet("{auctionId}")]
        public async Task<IActionResult> GetHistory(Guid auctionId)
        {
            List<AuctionHistory> history = await _dm.GetAuctionHistory(auctionId);
            return Json(history);
        }
    }
}
