using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet("reconcilliation")] 
        public async Task<IActionResult> Reconcilliation()
        {
            return Ok();
        }
    }
}
