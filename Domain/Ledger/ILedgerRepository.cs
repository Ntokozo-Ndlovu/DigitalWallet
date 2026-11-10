using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Ledger
{
    public interface ILedgerRepository
    {
        public Task<List<LedgerEntry>> FindLedgerEntryByTransactionId(Guid transactionId);
        public Task<List<LedgerEntry>> GetAllLedgerEntries();
        public Task<List<LedgerEntry>> GetAllWalletEntries(Guid walletId);
    }
}
