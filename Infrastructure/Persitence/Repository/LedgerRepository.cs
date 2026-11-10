using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;
using Infrastructure;
using Microsoft.Identity.Client;

namespace Infrastructure.Persitence.Repository
{
    public class LedgerRepository: ILedgerRepository
    {
        DwContext _dwContext;
        public LedgerRepository(DwContext context)
        {
            _dwContext = context;
        }
       public async Task<List<LedgerEntry>> FindLedgerEntryByTransactionId(Guid transactionId) {
            List<LedgerEntry> entries = _dwContext.LedgerEntry.Where(x => x.TransactionId == transactionId).ToList();
            return entries; 
        }
        public async Task<List<LedgerEntry>>  GetAllLedgerEntries()
        {
            List<LedgerEntry> allEntries = _dwContext.LedgerEntry.ToList();
            return allEntries;
        }
        public async Task<List<LedgerEntry>> GetAllWalletEntries(Guid walletId)
        {
            List<LedgerEntry> allWalletEntries = _dwContext.LedgerEntry.Where(x => x.WalletId == walletId).ToList();
            return allWalletEntries; 
        }
    }
}
