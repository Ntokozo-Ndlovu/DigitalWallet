using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Commands.Wallet
{
    public record WalletTransferCommand(Guid FromWalletId, Guid ToWalletId, decimal Amount, string Reference):IRequest;
}
