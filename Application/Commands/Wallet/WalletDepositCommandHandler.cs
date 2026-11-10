using Domain.Wallet;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Application.EventHandlers;
using MediatR;

namespace Application.Commands.Wallet
{
    public class WalletDepositCommandHandler:IRequestHandler<WalletDepositCommand>
    {
        IWalletRepository _walletRepo;
        IEventDispatcher _domainEventDispatcher;
        public WalletDepositCommandHandler(IWalletRepository walletRepo,
            IEventDispatcher domainEventDispatcher)
        {
            _walletRepo = walletRepo;
            _domainEventDispatcher = domainEventDispatcher;
        } 
        public async Task Handle(WalletDepositCommand cmd,CancellationToken tx) {
            try
            {
                Domain.Wallet.Wallet? wallet = await _walletRepo.FirstOrDefault(cmd.WalletId);
                if(wallet != null)
                {
                    wallet.Deposit(cmd.Amount,cmd.Reference);
                    List<DomainEvent> walletEventsSnapshot = wallet.DomainEvents.ToList();
                    await _domainEventDispatcher.DispatchDomainEvents(walletEventsSnapshot);
                    wallet.ClearDomainEvents();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
