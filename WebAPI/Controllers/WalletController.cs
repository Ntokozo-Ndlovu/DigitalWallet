using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Transactions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : Controller
    {

        [HttpPost("")]       
        public async Task<IActionResult> CreateWallet()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWallet()
        {
            return Ok();
        }


        [HttpPost("{Id}/deposit")]
        public  async Task<IActionResult> Deposit(Guid walletId)
        {
            return Ok();
        }

        [HttpPost("transfer")] 
        public async Task<IActionResult> Transfer()
        {
            return Ok();
        }
        public async Task<IActionResult> ReverseTransaction()
        {
            return Ok();        
        }

        [HttpPost("{Id}/withdrawals")]
        public async Task<IActionResult> Withdrawal()
        {
            return Ok();
        }


        }

}
