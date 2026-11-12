using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Commands.Wallet
{
    public record WalletDepositCommand(Guid WalletId,decimal Amount, string Reference):IRequest<WalletDTO>;
}
