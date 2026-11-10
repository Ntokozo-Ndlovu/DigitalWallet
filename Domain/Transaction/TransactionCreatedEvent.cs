using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Transaction
{
    public record TransactionCreatedEvent(Guid Id, Guid TransactionId): DomainEvent(Id)
    {
    }
}
