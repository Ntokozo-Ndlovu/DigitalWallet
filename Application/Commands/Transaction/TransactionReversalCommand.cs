using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Transaction
{
    public record TransactionReversalCommand(Guid TransactionId);
   
}
