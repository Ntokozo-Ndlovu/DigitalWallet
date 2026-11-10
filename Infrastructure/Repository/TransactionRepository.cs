using System;
using System.Collections.Generic;
using System.Text;
using Domain.Transaction;

namespace Infrastructure.Repository
{
    public class TransactionRepository:ITransactionRepository,IRepository
    {
        public TransactionRepository()
        {

        }
        public Task<Transaction> Add(Transaction Transaction);
        public Task<Transaction?> FirstOrDefault(Guid TransactionId);
    }
}
