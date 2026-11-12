using MediatR;
using Application.DTOs;

namespace Application.Commands.Transaction
{
    public record TransactionReversalCommand(Guid TransactionId):IRequest<TransactionDTO>;
   
}
