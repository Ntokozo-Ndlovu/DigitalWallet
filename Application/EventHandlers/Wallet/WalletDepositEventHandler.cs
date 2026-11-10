using Domain;
using Domain.Ledger;
using Domain.Transaction;
using Domain.Wallet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EventHandlers.Wallet
{
    public class WalletDepositEventHandler:IHandler<WalletDepositEvent>
    {
        ITransactionRepository _transactionRepo;
        ILedgerRepository _ledgerRepo;
        IWalletRepository _walletRepo;
        IUnitOfWork _unitOfWork;
        public WalletDepositEventHandler(IWalletRepository walletRepo,
            ITransactionRepository transactionRepo,
            ILedgerRepository ledgerRepo,
            IUnitOfWork unitOfWork)
        {
            _transactionRepo = transactionRepo;
            _ledgerRepo = ledgerRepo;
            _walletRepo = walletRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CancellationToken tk, WalletDepositEvent depositEvent)
        {
            try
            {
            Ledger ledger = await _ledgerRepo.FirstOrDefault();
            Domain.Wallet.Wallet? cashWallet = await _walletRepo.GetSystemWallet();//System 
            
            if(cashWallet != null)
            {
                Guid transactionId = Guid.NewGuid();
                Transaction transaction = Transaction.CreateTransaction(transactionId,TransactionType.Deposit, depositEvent.Amount, depositEvent.Reference); 
                Transaction systemTransaction = Transaction.CreateTransaction(transactionId,TransactionType.Deposit, depositEvent.Amount, depositEvent.Reference);
                ledger.AppendTransaction(transactionId,cashWallet.Id, depositEvent.WalletId,depositEvent.Amount);
                await _transactionRepo.Add(transaction);
                await _transactionRepo.Add(systemTransaction);
                await _unitOfWork.SaveChanges();
            }
            }
            catch (Exception e) { }
        }
    }
}
