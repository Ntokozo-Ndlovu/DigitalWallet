using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Ledger
{
    public record LedgerEntry
    {
        public Guid Id { get; }
        public Guid TransactionId { get; }
        public Guid WalletId { get; }
        public decimal Amount { get; }
        public DateTime CreatedAtUtc { get; } 
        private LedgerEntry()
        {

        }
        public LedgerEntry(Guid transactionId, Guid walletId, decimal amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            WalletId = walletId;
            CreatedAtUtc = DateTime.UtcNow;
        }
  
        
    }
}
