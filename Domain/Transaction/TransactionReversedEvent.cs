using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Transaction
{
    public record TransactionReversedEvent(Guid Id, Guid TransactionId) : DomainEvent(Id);
}
