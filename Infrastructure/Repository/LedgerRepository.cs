using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;

namespace Infrastructure.Repository
{
    public class LedgerRepository: ILedgerRepository,IRepository
    {
        public LedgerRepository()
        {

        }
        public Task<Ledger> FirstOrDefault();
        public Task<List<LedgerEntry>> FindLedgerEntryByTransactionId(Guid transactionId);
    }
}
