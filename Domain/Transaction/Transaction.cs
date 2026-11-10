using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Transaction
{
    public class Transaction:AggregateRoot
    {
        public Guid Id { get;  }
        public TransactionType TransactionType { get; private set; }
        public Guid TransactionId { get; }
        public decimal Amount { get; }
        public decimal Fee { get; }
        public string Reference { get; }
        public Guid ReversalOfId { get; private set; }
        public DateTime CreatedAtUTC { get; }
    
        public Transaction() {  }

        public Transaction(Guid transactionId,TransactionType type, decimal amount, string reference) {
            Id = Guid.NewGuid();
            TransactionId = transactionId;
            TransactionType = type;
            Amount = amount;
            Reference = reference;
            CreatedAtUTC = DateTime.UtcNow;
        }
        public static Transaction CreateTransaction(Guid transactionId, TransactionType type, decimal amount, string reference)
        {
            if (String.IsNullOrEmpty(reference))
                throw new DomainException("Reference required");
            Transaction transaction = new Transaction(transactionId,type,amount,reference);
          //  RaiseDomainEvent(new TransactionCreatedEvent(Guid.NewGuid(), transaction.Id));
            return transaction;
        }

        public void ReverseTransaction()
        { 
            if (TransactionType == TransactionType.Reversal)
                throw new Exception("transaction already reversed");
            TransactionType = TransactionType.Reversal;
            RaiseDomainEvent(new TransactionReversedEvent(Guid.NewGuid(),this.Id)); //will raise an event to reverse the transaction on app layer 
        }
    }
}
