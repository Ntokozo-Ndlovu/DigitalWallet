using System;
using System.Collections.Generic;
using System.Text;
using Domain.Ledger;

namespace Application.Services
{
    public interface ILedgerService
    {
        public Task<Ledger> GetLedger();

    }
}
