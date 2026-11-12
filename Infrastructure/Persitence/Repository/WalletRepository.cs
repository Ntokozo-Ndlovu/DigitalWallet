using System;
using System.Collections.Generic;
using System.Text;
using Domain.Wallet;

namespace Infrastructure.Persitence.Repository
{
    public class WalletRepository:IWalletRepository
    {
        DwContext _dbContext;
        public WalletRepository(DwContext context)
        {
            _dbContext = context;
        }
        public async Task<Wallet?> FirstOrDefault(Guid Id)
        {
            Wallet? wallet = _dbContext.Wallet.FirstOrDefault(x => x.Id ==Id);
            return wallet;
        }
        public async Task<Wallet?> GetSystemWallet()
        {
            Wallet? wallet = _dbContext.Wallet.FirstOrDefault(x => x.WalletType == WalletType.System);
            return wallet;
        }
        public async Task<Wallet?> Add(Wallet wallet)
        {
            var walletEntityEntry = await _dbContext.Wallet.AddAsync(wallet);
            return walletEntityEntry.Entity;
        }
        }
}
