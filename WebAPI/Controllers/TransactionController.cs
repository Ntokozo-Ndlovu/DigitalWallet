using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {

        [HttpPost()]     
         public async Task<IActionResult> Transfer()
        {
            return Ok();
        }

        [HttpPost("{transactionId}")] 
        public async Task<IActionResult> Reverse(Guid transactionId)
        {
            return Ok();
        }
    }
}
