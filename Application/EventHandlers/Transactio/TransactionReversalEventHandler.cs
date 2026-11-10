using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Ledger;
using Domain.Transaction;

namespace Application.EventHandlers.Transactio
{
    public class TransactionReversalEventHandler:IHandler<TransactionReversedEvent>
    {
        ITransactionRepository _transactionRepo;
        ILedgerRepository _ledgerRepo;
        IUnitOfWork _unitOfWork; 

        public TransactionReversalEventHandler(
           ITransactionRepository transactionRepository,
           ILedgerRepository ledgerRepository,
           IUnitOfWork unitOfWork
            )
        {

            _transactionRepo = transactionRepository;
            _unitOfWork = unitOfWork;
            _ledgerRepo = ledgerRepository;
        }
        public async Task HandleAsync(CancellationToken tk, TransactionReversedEvent transactionEvent)
        {
            

        }
    }
}
