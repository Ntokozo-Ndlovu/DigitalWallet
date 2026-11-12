using Application.Commands.Wallet;
using Domain.Wallet;
using Domain.Transaction;
using Domain.Ledger;
using Domain;
using Application.Services;

namespace Application.EventHandlers.Wallet
{
    public class WalletReversalEventHandler:IHandler<WalletReversalEvent>
    {
       
        private IUnitOfWork _unitOfWork;
        private IWalletRepository _walletRepo;
        private ILedgerRepository _ledgerRepo;
        private ITransactionRepository _transactionRepo;
        private ILedgerService _ledgerService;
        public WalletReversalEventHandler(
            IUnitOfWork unitOfWork, 
            ILedgerService ledgerService,
            IWalletRepository walletRepo,
            ILedgerRepository ledgerRepo,
            ITransactionRepository transactionRepo)
        {
            _unitOfWork = unitOfWork;
            _walletRepo = walletRepo;
            _ledgerRepo = ledgerRepo;
            _transactionRepo = transactionRepo;
            _ledgerService = ledgerService;
        }
      
        public async Task HandleAsync(CancellationToken tk, WalletReversalEvent reversalEvent)
        {
            try
            {
            List<LedgerEntry> transactionLedgerEntries = await _ledgerRepo.FindLedgerEntryByTransactionId(reversalEvent.TransactionId);
            LedgerEntry? toLedgerEntry = transactionLedgerEntries.FirstOrDefault(x => x.Amount > 0);
            LedgerEntry? fromLedgerEntry = transactionLedgerEntries.FirstOrDefault(x => x.Amount < 0);
            if(toLedgerEntry != null && fromLedgerEntry != null)
            {
                Guid transactionId = Guid.NewGuid();
                Transaction toTransaction = Transaction.CreateTransaction(transactionId,TransactionType.Reversal,fromLedgerEntry.Amount,"Reversal");
                Transaction fromTransaction = Transaction.CreateTransaction(transactionId,TransactionType.Reversal,toLedgerEntry.Amount,"Reversal");
                Ledger ledger = await _ledgerService.GetLedger();
                ledger.AppendTransaction(transactionId,toLedgerEntry.WalletId,fromLedgerEntry.WalletId,toLedgerEntry.Amount);
                await _transactionRepo.Add(toTransaction);
                await _transactionRepo.Add(fromTransaction);
                await _unitOfWork.SaveChanges();
                //we want to do an interesting thing. Create two new transactions                
            }

            }
            catch (Exception ex)
            {
                //Will still be handled
            }
            //reversing a transaction means creating to new transactions in the opposite direction
            //we need to find the right wallets first. then create new transactions. 
         //   Transaction fromTransaction = Transaction.CreateTransaction(ledgerEntry);  
          //  Transaction toTransaction = Transaction.CreateTransaction();  
        }
    }
}
