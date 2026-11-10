using Application.Commands.Wallet;
using Domain.Wallet;
using Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;
using Domain;
using Application.EventHandlers;

namespace Application.Handlers.Wallet
{
    public class WalletTransferEventHandler: IHandler<WalletTransferEvent>
    {
        private IUnitOfWork _unitOfWork;
        private IWalletRepository _walletRepo;
        private ILedgerRepository _ledgerRepo;
        private ITransactionRepository _transactionRepo;
        public WalletTransferEventHandler(
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
        public async Task HandleAsync(CancellationToken t, WalletTransferEvent walletEvent)
        {
            try {
            
            Guid transactionId = Guid.NewGuid();
            Transaction fromTransaction = Transaction.CreateTransaction(transactionId,TransactionType.Transfer, -walletEvent.Amount,walletEvent.Reference);
            Transaction toTransaction = Transaction.CreateTransaction(transactionId,TransactionType.Transfer,walletEvent.Amount,walletEvent.Reference);
            Ledger ledger =  await _ledgerRepo.FirstOrDefault();
            ledger.AppendTransaction(transactionId, walletEvent.FromWalletId, walletEvent.ToWalletId,walletEvent.Amount);
            await _transactionRepo.Add(fromTransaction);
            await _transactionRepo.Add(toTransaction);
            await _unitOfWork.SaveChanges();              
            }
            catch (Exception ex)
            {

            }
                       
        }
    }
}
