using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Commands.Wallet
{
    public record WalletWithdrawCommand(Guid WalletId, decimal Amount):IRequest;
}
