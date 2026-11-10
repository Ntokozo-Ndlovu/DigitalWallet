using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Ledger
{
    public record LedgerAddTransaction(Guid Id, Guid TransactionId) : DomainEvent(Id);
}
