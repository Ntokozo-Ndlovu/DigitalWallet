using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using Application.Commands.Transaction;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        ISender _sender; 
        public TransactionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("{transactionId}")] 
        public async Task<IActionResult> Reverse(Guid transactionId)
        {
            TransactionReversalCommand enrichedCmd = new TransactionReversalCommand(transactionId);
            var wallet =  await _sender.Send(enrichedCmd);
            return Ok();
        }
    }
}
