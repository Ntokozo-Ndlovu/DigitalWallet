using Domain.Ledger;
using Domain.Transaction;
using Domain.Wallet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class WalletService {
        ITransactionRepository _transactionRepo;
        ILedgerRepository _ledgerRepo;
        IWalletRepository _walletRepo;
        private Wallet? _wallet { get; set; }
        public WalletService(ITransactionRepository transactionRepo,
            ILedgerRepository ledgerRepo,
            IWalletRepository walletRepo)
        {
            _transactionRepo = transactionRepo;
            _ledgerRepo = ledgerRepo;
            _walletRepo = walletRepo;
        }
        
        public async Task<Wallet?> GetWallet(Guid walletId)
         {
            if (_wallet != null)
                return _wallet;
            _wallet = await _walletRepo.FirstOrDefault(walletId);
            
            if(_wallet != null)
            {
                List<LedgerEntry> wallerLedgerEntries = await _ledgerRepo.GetAllWalletEntries(walletId);
                decimal balance = wallerLedgerEntries.Sum(x => x.Amount);
                _wallet = new Wallet(_wallet.Id,_wallet.OwnerId,_wallet.Currency,_wallet.WalletType,balance);
                
            }
            return _wallet;
        }
    }
}
