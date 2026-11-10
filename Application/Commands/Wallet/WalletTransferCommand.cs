using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Wallet
{
    public record WalletTransferCommand(Guid FromWalletId, Guid ToWalletId, decimal Amount, string Reference);
}
