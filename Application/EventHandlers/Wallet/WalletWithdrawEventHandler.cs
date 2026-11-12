using Domain.Wallet;
using Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;
using Domain;
using Application.Services;

namespace Application.EventHandlers.Wallet
{
    public class WalletWithdrawEventHandler:IHandler<WalletWithdrawalEvent>
    {
        ITransactionRepository _transactionRepo;
        ILedgerRepository _ledgerRepo;
        IWalletRepository _walletRepo;
        IUnitOfWork _unitOfWork;
        ILedgerService _ledgerService;
        IWalletService _walletService;
        public WalletWithdrawEventHandler(ILedgerRepository ledgeRepository,
            ITransactionRepository transactionRepo,
            IWalletRepository walletRepo,
            ILedgerService ledgerService,
            IWalletService walletService,
            IUnitOfWork unitOfWork)
        {
            _ledgerRepo = ledgeRepository;
            _walletRepo = walletRepo; 
            _unitOfWork = unitOfWork;
            _ledgerService = ledgerService;
            _walletService = walletService;
            _transactionRepo = transactionRepo;
        }       
        public async Task HandleAsync(CancellationToken tk,WalletWithdrawalEvent withdrawalEvent)
        {
            try
            {
                //Transaction needs to go through on the ledger
                    Ledger ledger = await _ledgerService.GetLedger();
                    Guid transactionId = Guid.NewGuid();
                    Transaction cashTransanction = Transaction.CreateTransaction(transactionId, TransactionType.Withdrawal, withdrawalEvent.amount, "Withdrawal");
                    Transaction walletTransanction = Transaction.CreateTransaction(transactionId, TransactionType.Withdrawal, withdrawalEvent.amount, "Withdrawal");
                    ledger.AppendTransaction(transactionId, withdrawalEvent.WalletId, Guid.Empty, withdrawalEvent.amount);
                    await _transactionRepo.Add(cashTransanction);
                    await _transactionRepo.Add(walletTransanction);
                    await _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            //I need update add the new transactions
        }
    }
}
