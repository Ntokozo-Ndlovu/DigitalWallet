using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Wallet
{
    public record WalletReversalEvent(Guid Id, Guid WalletId, Guid TransactionId) : DomainEvent(Id);
}
