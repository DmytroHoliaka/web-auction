using Microsoft.AspNetCore.Mvc;

namespace WebAuction.Backend.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GetMainPage()
        {
            string content = System.IO.File.ReadAllText("Frontend/index.html");
            return Content(content, "text/html");
        }
    }
}
