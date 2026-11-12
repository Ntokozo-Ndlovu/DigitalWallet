using Domain.Wallet;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Application.DTOs;

namespace Application.Commands.Wallet
{
    public record WalletCreateCommand(Guid Id, Guid OwnerId, string Currency):IRequest<WalletDTO>;
}
