using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Wallet
{
    public record WalletCreatedEvent(Guid Id,Guid walletId) : DomainEvent(Id);
}
