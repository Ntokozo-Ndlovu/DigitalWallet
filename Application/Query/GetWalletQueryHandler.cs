using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Query
{
    public class GetWalletQueryHandler:IRequestHandler<GetWalletQuery,WalletDTO>
    {

        public async Task<WalletDTO> Handle(GetWalletQuery query, CancellationToken ct)
        {

            return new WalletDTO();
        }
    }
}
