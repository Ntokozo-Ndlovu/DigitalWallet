using Domain.Wallet;
using Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;
using Domain;

namespace Application.EventHandlers.Wallet
{
    public class WalletWithdrawEventHandler:IHandler<WalletWithdrawalEvent>
    {
        ITransactionRepository _transactionRepo;
        ILedgerRepository _ledgerRepo;
        IWalletRepository _walletRepo;
        IUnitOfWork _unitOfWork;
        public WalletWithdrawEventHandler(ILedgerRepository ledgeRepository,
            ITransactionRepository transactionRepo,
            IWalletRepository walletRepo,
            IUnitOfWork unitOfWork)
        {
            _ledgerRepo = ledgeRepository;
            _walletRepo = walletRepo; 
            _unitOfWork = unitOfWork;
            _transactionRepo = transactionRepo;
        }       
        public async Task HandleAsync(CancellationToken tk,WalletWithdrawalEvent withdrawalEvent)
        {
            //Transaction needs to go through on the ledger
            Ledger ledger = await _ledgerRepo.FirstOrDefault();
            Domain.Wallet.Wallet? walletCash = await _walletRepo.GetCashWallet();   
            if(walletCash != null)
            {
                Guid transactionId = Guid.NewGuid();
                Transaction cashTransanction = Transaction.CreateTransaction(transactionId,TransactionType.Withdrawal,withdrawalEvent.amount, "Withdrawal"); 
                Transaction walletTransanction = Transaction.CreateTransaction(transactionId,TransactionType.Withdrawal,withdrawalEvent.amount, "Withdrawal");
                ledger.AppendTransaction(transactionId,withdrawalEvent.WalletId,walletCash.Id,withdrawalEvent.amount);
                await _transactionRepo.Add(cashTransanction);
                await _transactionRepo.Add(walletTransanction);
                await  _unitOfWork.SaveChanges();
            
            }

            //I need update add the new transactions
        }
    }
}
