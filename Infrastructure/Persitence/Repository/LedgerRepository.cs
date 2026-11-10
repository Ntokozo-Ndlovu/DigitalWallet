using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;
using Infrastructure;

namespace Infrastructure.Persitence.Repository
{
    public class LedgerRepository: ILedgerRepository
    {
        public LedgerRepository(DwContext context)
        {

        }
        public Task<Ledger> FirstOrDefault() { }
        public Task<List<LedgerEntry>> FindLedgerEntryByTransactionId(Guid transactionId) { }
    }
}
