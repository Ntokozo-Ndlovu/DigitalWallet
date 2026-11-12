using Application.EventHandlers;
using Domain;
using Domain.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Commands.Wallet
{
    public class WalletTransferCommandHandler: IRequestHandler<WalletTransferCommand,WalletDTO>
    {
        IWalletRepository _walletRepo;
        IEventDispatcher _eventDispatcher;
        public WalletTransferCommandHandler(IWalletRepository walletRepo,
            IEventDispatcher dispatcher)
        {
            _walletRepo = walletRepo;
            _eventDispatcher = dispatcher;
        }
        public async Task<WalletDTO> Handle(WalletTransferCommand cmd,CancellationToken tk)
        {
            Domain.Wallet.Wallet? wallet = await _walletRepo.FirstOrDefault(cmd.FromWalletId);
            try
            {
                if (wallet != null)
                {
                    wallet.TransferToWallet(cmd.ToWalletId, cmd.Amount, cmd.Reference);
                    //Need to dispatch events.
                    List<DomainEvent> walletEventsSnapshot = wallet.DomainEvents.ToList();
                    await _eventDispatcher.DispatchDomainEvents(walletEventsSnapshot);

                    wallet.ClearDomainEvents();
                } 
              
                }
            catch (Exception ex)
            {
                // handle 
            }
            return new WalletDTO();
        }
    }
}
