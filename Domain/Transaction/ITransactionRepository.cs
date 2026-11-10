using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Transaction
{
    public interface ITransactionRepository
    {
        public Task<Transaction> Add(Transaction Transaction);
        public Task<Transaction?> FirstOrDefault(Guid TransactionId);
    }
}
