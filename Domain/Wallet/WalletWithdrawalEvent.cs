using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Wallet
{
    public record WalletWithdrawalEvent(Guid Id, Guid WalletId, decimal amount) : DomainEvent(Id);
}
