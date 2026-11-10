using Domain.Wallet;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Application.EventHandlers;

namespace Application.Commands.Wallet
{
    public class WalletDepositCommandHandler:ICommandHandler<WalletDepositCommand>
    {
        IWalletRepository _walletRepo;
        IEventDispatcher _domainEventDispatcher;
        public WalletDepositCommandHandler(IWalletRepository walletRepo,
            IEventDispatcher domainEventDispatcher)
        {
            _walletRepo = walletRepo;
            _domainEventDispatcher = domainEventDispatcher;
        } 
        public async Task ExecuteAsync(CancellationToken t, WalletDepositCommand cmd) {
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
