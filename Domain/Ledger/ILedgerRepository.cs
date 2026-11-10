using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Ledger
{
    public interface ILedgerRepository
    {
        public Task<Ledger> FirstOrDefault();
        public Task<LedgerEntry> FindLedgerEntryByTransactionId(Guid transactionId);
    }
}
