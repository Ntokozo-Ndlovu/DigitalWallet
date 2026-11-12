using MediatR;
using Domain;
using Domain.Wallet;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Commands.Wallet
{
    public class WalletCreateCommandHandler:IRequestHandler<WalletCreateCommand,WalletDTO>
    {
        IWalletRepository _walletRepo;
        IEventDispatcher _eventDispatcher;
        public WalletCreateCommandHandler(IWalletRepository walletRepo, IEventDispatcher eventDispatcher)
        {
            _walletRepo = walletRepo;
            _eventDispatcher = eventDispatcher;
        }
        public async Task<WalletDTO> Handle(WalletCreateCommand createCmd,CancellationToken tk)
        {
            Domain.Wallet.Wallet wallet = Domain.Wallet.Wallet.CreateWallet(createCmd.OwnerId,createCmd.Currency, WalletType.User);
            await _walletRepo.Add(wallet);
            List<DomainEvent> domainEventsSnapshot = new (wallet.DomainEvents);
            await _eventDispatcher.DispatchDomainEvents(domainEventsSnapshot);
            wallet.ClearDomainEvents();
            return new WalletDTO();
        }
    }
}
