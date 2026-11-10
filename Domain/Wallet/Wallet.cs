using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Domain.Wallet
{
    public class Wallet:AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Currency { get; private set; }
        public WalletType WalletType { get; private set; }
        public decimal Balance { get; private set; }//It wont be store will be calculated on data fetch
        private Wallet()
        {

        }
        private Wallet(Guid ownerId, string currency, WalletType walletType,decimal balance )
        {
            this.Id = Guid.NewGuid();
            this.OwnerId = ownerId;
            this.Currency = currency;
            this.WalletType = walletType;
            this.Balance = balance;
        }
        public static Wallet CreateWallet(Guid ownerId, string currency, WalletType walletType)
        {
            if (ownerId == Guid.Empty)
                throw new DomainException("OwnerId is required"); 
            if (String.IsNullOrEmpty(currency))
                throw new DomainException("Currency can not be empty or null"); 
            
            Wallet wallet = new  Wallet( ownerId, currency, walletType, 0);
           
         //   RaiseDomainEvent(new WalletCreatedEvent(Guid.NewGuid(), wallet.Id)); 
            return wallet; 
        }
        public void Deposit(decimal amount, string reference)
        {
            if(amount <= 0)
                throw new DomainException("Amount needs to be greater than 0");
            if (String.IsNullOrEmpty(reference))
                throw new DomainException("Reference required");

            RaiseDomainEvent(new WalletDepositEvent(Guid.NewGuid(),Id,amount,reference));
        }
        public void TransferToWallet(Guid toWalletId, decimal amount, string reference) 
        {
            if (toWalletId == Guid.Empty)
                throw new DomainException("Id for the wallet you sending to is required.");

            if (String.IsNullOrEmpty(reference))
                throw new DomainException("Reference required to make a transfer.");
            if (amount > this.Balance)
                throw new DomainException("Insufficient funds to transfer.");
            RaiseDomainEvent(new WalletTransferEvent(Guid.NewGuid(), this.Id, toWalletId, amount,reference));
            //Good make needs to happen here
        }
 
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new DomainException("Can not withdraw more than avalailable balance.");
            RaiseDomainEvent(new WalletWithdrawalEvent(Guid.NewGuid(),this.Id,amount));
        }

        public void ReverseTransaction(Guid transactionId)
        {
            if (transactionId == Guid.Empty)
                throw new DomainException("TransactionId required for reversal");
            RaiseDomainEvent(new WalletReversalEvent(Guid.NewGuid(), this.Id,transactionId)); 
        }
           
    }
}
