using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Query

{
    public record GetWalletQuery(Guid OwnerId):IRequest<WalletDTO>;
}
