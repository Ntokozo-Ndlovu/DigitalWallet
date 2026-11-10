using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Wallet
{
    public record WalletTransferEvent(Guid Id,Guid FromWalletId, Guid ToWalletId, decimal Amount, string Reference) : DomainEvent(Id);
}
