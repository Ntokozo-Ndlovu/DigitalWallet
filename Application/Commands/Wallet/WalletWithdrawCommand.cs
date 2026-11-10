using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Wallet
{
    public record WalletWithdrawCommand(Guid WalletId, decimal Amount);
}
