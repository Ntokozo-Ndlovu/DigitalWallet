using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Wallet
{
    public record WalletDepositEvent(Guid Id, Guid WalletId,decimal Amount,string Reference) : DomainEvent(Id);
}
