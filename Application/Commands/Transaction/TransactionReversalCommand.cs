using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MediatR;
namespace Application.Commands.Transaction
{
    public record TransactionReversalCommand(Guid TransactionId):IRequest;
   
}
