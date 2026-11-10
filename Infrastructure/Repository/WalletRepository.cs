using System;
using System.Collections.Generic;
using System.Text;
using Domain.Wallet;

namespace Infrastructure.Repository
{
    public class WalletRepository:IWalletRepository
    {

        public WalletRepository()
        {

        }
        public async Task<Wallet?> FirstOrDefault(Guid Id)
        {

        }
        public async Task<Wallet?> GetSystemWallet()
        {

        }
        public async Task<Wallet?> GetCashWallet() { }
    }
}
