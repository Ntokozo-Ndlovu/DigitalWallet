using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Domain.Transaction;

namespace Infrastructure.Persitence.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        DwContext _dwContext;
        public TransactionRepository(DwContext context)
        {
            _dwContext = context;
        }
        public async Task<Domain.Transaction.Transaction> Add(Transaction transaction)
        {
           var entityEntry =  _dwContext.Transaction.Add(transaction);
            return entityEntry.Entity; 
        }
        public async Task<Domain.Transaction.Transaction?> FirstOrDefault(Guid transactionId)
        {
          Domain.Transaction.Transaction? transaction =  _dwContext.Transaction.FirstOrDefault(x => x.TransactionId == transactionId);
           return transaction;
        }
    }
}
