using Domain.Ledger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class LedgerService:ILedgerService
    {
       private Ledger? _ledger { set; get; }
        private ILedgerRepository _ledgerRepo; 
       public LedgerService(ILedgerRepository ledgerRepo)
       {
            _ledgerRepo = ledgerRepo;
       } 

      public async Task<Ledger> GetLedger()
        {
            if (_ledger == null)
            {
            List<LedgerEntry> ledgerEntries = await _ledgerRepo.GetAllLedgerEntries();
            Ledger ledger = new Ledger(ledgerEntries);
                return ledger;
            }  
            return _ledger; 
            } 

    }
}
