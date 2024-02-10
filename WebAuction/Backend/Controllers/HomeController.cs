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
        public async Task<IActionResult> GetMainPage()
        {
            string content = await System.IO.File.ReadAllTextAsync("Frontend/index.html");
            return Content(content, "text/html");
        }

        [HttpGet("Data/AuctionSummaries")]
        public async Task<IActionResult> GetAllAuctions()
        {
            List<AuctionSummary> auctions = await _db.AuctionSummaries.ToListAsync();
            return Json(auctions);
        }
    }
}
