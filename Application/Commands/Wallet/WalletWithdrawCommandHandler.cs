using Application.EventHandlers;
using Domain;
using Domain.Wallet;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Commands.Wallet
{
    public class WalletWithdrawCommandHandler:ICommandHandler<WalletWithdrawCommand>
    {
        public IWalletRepository _walletRepo;
        public IEventDispatcher _dispatcher;
        public WalletWithdrawCommandHandler(IWalletRepository walletRepo,
            IEventDispatcher dispatcher)
        {
            _walletRepo = walletRepo;
            _dispatcher = dispatcher;
        }

        public async Task ExecuteAsync(CancellationToken tk, WalletWithdrawCommand cmd)
        {
            try
            {
                Domain.Wallet.Wallet wallet = await  _walletRepo.FirstOrDefault(cmd.WalletId);
                wallet.Withdraw(cmd.Amount);
                List<DomainEvent> domainEventsSnapshots = new List<DomainEvent>(wallet.DomainEvents);
                await _dispatcher.DispatchDomainEvents(domainEventsSnapshots);
            }
            catch(Exception e)
            {

            }
        }
    }
}
