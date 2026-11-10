using Domain.Wallet;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Application.EventHandlers;
using MediatR;

namespace Application.Commands.Wallet
{
    public class WalletReversalCommandHandler:IRequestHandler<WalletReversalCommand>
    {
        IWalletRepository _walletRepo;
        IEventDispatcher _dispatcher;
        public WalletReversalCommandHandler(IWalletRepository walletRepo,
            IEventDispatcher dispatcher)
        {
            _walletRepo = walletRepo;
            _dispatcher = dispatcher;
        }
        public async Task Handle(WalletReversalCommand cmd,CancellationToken ct)
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
