using Domain.Wallet;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Application.EventHandlers;

namespace Application.Commands.Wallet
{
    public class WalletReversalCommandHandler:ICommandHandler<WalletReversalCommand>
    {
        IWalletRepository _walletRepo;
        IEventDispatcher _dispatcher;
        public WalletReversalCommandHandler(IWalletRepository walletRepo,
            IEventDispatcher dispatcher)
        {
            _walletRepo = walletRepo;
            _dispatcher = dispatcher;
        }
        public async Task ExecuteAsync(CancellationToken t, WalletReversalCommand cmd)
        {
            try
            {
                Domain.Wallet.Wallet? wallet = await _walletRepo.FirstOrDefault(cmd.WalletId);
                wallet?.ReverseTransaction(cmd.TransactionId);
                List<DomainEvent> walletDomainEventsSnapshot = wallet != null?wallet.DomainEvents.ToList(): new List<DomainEvent>();
                await _dispatcher.DispatchDomainEvents(walletDomainEventsSnapshot);
                wallet?.ClearDomainEvents();
            }
            catch (Exception e)
            {

            }
        }
    }
}
