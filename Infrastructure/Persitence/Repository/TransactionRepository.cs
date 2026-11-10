using System;
using System.Collections.Generic;
using System.Text;
using Domain.Transaction;

namespace Infrastructure.Persitence.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        public TransactionRepository(DwContext context)
        {

        }
        public Task<Transaction> Add(Transaction Transaction);
        public Task<Transaction?> FirstOrDefault(Guid TransactionId);
    }
}
