using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Application.DTOs;

namespace Application.Commands.Wallet
{
    public record WalletReversalCommand(Guid WalletId, Guid TransactionId) : IRequest<WalletDTO>;
}
