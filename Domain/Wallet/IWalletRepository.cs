using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Wallet
{
    public interface IWalletRepository
    {
        public Task<Wallet?> FirstOrDefault(Guid Id);
        public Task<Wallet?> GetSystemWallet();
        public Task<Wallet?> Add(Wallet wallet);
        }
}
