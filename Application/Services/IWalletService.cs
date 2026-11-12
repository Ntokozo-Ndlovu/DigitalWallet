using System;
using System.Collections.Generic;
using System.Text;
using Domain.Wallet;

namespace Application.Services
{
    public interface IWalletService
    {
        public Task<Wallet?> GetWallet(Guid ownerId);
        }
}
