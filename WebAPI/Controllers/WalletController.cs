using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Transactions;
using MediatR;
using Application.Commands.Wallet;
using Application.Query;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : Controller
    {
        ISender _sender;
        public WalletController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost("")]       
        public async Task<IActionResult> CreateWallet(WalletCreateCommand cmd)
        {
            await _sender.Send(cmd);            
            return Ok();
        }
        [HttpGet("{ownerId}")]
        public async Task<IActionResult> GetWallet([FromQuery] Guid ownerId)
        {
            GetWalletQuery query = new GetWalletQuery(Guid.Empty);
            var wallet = await _sender.Send(query);
           //query wallet 
            return Ok(wallet);
        }


        [HttpPost("{walletId}/deposit")]
        public  async Task<IActionResult> Deposit(Guid walletId, [FromBody] WalletDepositCommand cmd)
        {
            var something = await _sender.Send(cmd);
            return Ok();
        }

        [HttpPost("transfer")] 
        public async Task<IActionResult> Transfer(WalletTransferCommand cmd)
        {
            var transaction = _sender.Send(cmd);
            return Ok();
        }
        public async Task<IActionResult> ReverseTransaction(WalletReversalCommand cmd)
        {
            var transaction = await _sender.Send(cmd);
            return Ok();        
        }

        [HttpPost("{Id}/withdrawals")]
        public async Task<IActionResult> Withdrawal(WalletWithdrawCommand cmd)
        {
            var transaction = await _sender.Send(cmd);
            return Ok();
        }


        }

}
