using Application.Services;
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
        ILedgerService _ledgerService; 
        IUnitOfWork _unitOfWork;
        public WalletDepositEventHandler(IWalletRepository walletRepo,
            ITransactionRepository transactionRepo,
            ILedgerRepository ledgerRepo,
            ILedgerService ledgerService,
            IUnitOfWork unitOfWork)
        {
            _transactionRepo = transactionRepo;
            _ledgerRepo = ledgerRepo;
            _walletRepo = walletRepo;
            _ledgerService = ledgerService;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CancellationToken tk, WalletDepositEvent depositEvent)
        {
            try
            {
                Ledger ledger = await _ledgerService.GetLedger();  
                Guid transactionId = Guid.NewGuid();
                Transaction transaction = Transaction.CreateTransaction(transactionId,TransactionType.Deposit, depositEvent.Amount, depositEvent.Reference); 
                Transaction cashTransaction = Transaction.CreateTransaction(transactionId,TransactionType.Deposit, depositEvent.Amount, depositEvent.Reference);
                ledger.AppendTransaction(transactionId,Guid.Empty, depositEvent.WalletId,depositEvent.Amount);
                await _transactionRepo.Add(transaction);
                await _transactionRepo.Add(cashTransaction);
                await _unitOfWork.SaveChanges();
            }
            catch (Exception e) { }
        }
    }
}
