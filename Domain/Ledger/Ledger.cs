using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Domain.Ledger
{
    public class Ledger:AggregateRoot
    {
        public IReadOnlyList<LedgerEntry> LedgerEntries { get => _ledgerEntries; }
        private List<LedgerEntry> _ledgerEntries { get;  set; }
        public Ledger() { }
        public void AppendTransaction(Guid transactionId,Guid fromWalletId, Guid toWalletId,decimal amount)
        {
            if (transactionId == Guid.Empty)
                throw new DomainException("TransactionId is required");
            if (fromWalletId == Guid.Empty)
                throw new DomainException("From walletId is required");  
            if (fromWalletId == Guid.Empty)
                throw new DomainException("to walletId is required");
            if (amount < 0)
                throw new DomainException("Invalid transaction, amount must be > 0");
            LedgerEntry fromEntry = new LedgerEntry(transactionId,fromWalletId, -amount);
            LedgerEntry toEntry = new LedgerEntry(transactionId,toWalletId,amount);
            _ledgerEntries.Add(fromEntry);
            _ledgerEntries.Add(toEntry);
            RaiseDomainEvent(new LedgerAddTransaction(Guid.NewGuid(), transactionId));
        }
    }
}
