using Domain;
using Domain.Transaction;
using Application.DTOs;
using MediatR;

namespace Application.Commands.Transaction
{
    public class TransactionReversalCommadHandler:IRequestHandler<TransactionReversalCommand,TransactionDTO>{
        ITransactionRepository _transactionRepo;
        IEventDispatcher _eventDispatcher;
        IUnitOfWork _unitOfWork;
        public TransactionReversalCommadHandler(ITransactionRepository transactionRepo,
            IEventDispatcher eventDispatcher,
            IUnitOfWork unitOfWork) {
            _transactionRepo = transactionRepo;
            _eventDispatcher = eventDispatcher;
            _unitOfWork = unitOfWork;
        }
            public async Task<TransactionDTO> Handle(TransactionReversalCommand cmd,CancellationToken tk)
        {
            try {
                Domain.Transaction.Transaction? transaction = await _transactionRepo.FirstOrDefault(cmd.TransactionId); 
                if(transaction != null)
                {
                    transaction.ReverseTransaction();
                    List<DomainEvent> domainEventsSnapshot = transaction.DomainEvents.ToList();
                    transaction.ClearDomainEvents();
                    await _unitOfWork.SaveChanges();
                    await _eventDispatcher.DispatchDomainEvents(domainEventsSnapshot);
                }
            }
            catch (Exception e)
            {

            }
            return new TransactionDTO();
        }
    }
}
