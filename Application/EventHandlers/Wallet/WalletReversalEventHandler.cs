using Application.Commands.Wallet;
using Domain.Wallet;
using Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;
using Domain;
using Application.EventHandlers;

namespace Application.EventHandlers.Wallet
{
    public class WalletReversalEventHandler:IHandler<WalletReversalEvent>
    {
       
        private IUnitOfWork _unitOfWork;
        private IWalletRepository _walletRepo;
        private ILedgerRepository _ledgerRepo;
        private ITransactionRepository _transactionRepo;
        public WalletReversalEventHandler(
            IUnitOfWork unitOfWork, 
            IWalletRepository walletRepo,
            ILedgerRepository ledgerRepo,
            ITransactionRepository transactionRepo)
        {
            _unitOfWork = unitOfWork;
            _walletRepo = walletRepo;
            _ledgerRepo = ledgerRepo;
            _transactionRepo = transactionRepo;
        }
      
        public async Task HandleAsync(CancellationToken tk, WalletReversalEvent reversalEvent)
        {
            //reversing a transaction means creating to new transactions in the opposite direction
            //we need to find the right wallets first. then create new transactions. 
            LedgerEntry ledgerEntry = await _ledgerRepo.FindLedgerEntryByTransactionId(reversalEvent.TransactionId);
         //   Transaction fromTransaction = Transaction.CreateTransaction(ledgerEntry);  
          //  Transaction toTransaction = Transaction.CreateTransaction();  
        }
    }
}
