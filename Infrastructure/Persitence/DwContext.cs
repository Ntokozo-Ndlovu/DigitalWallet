using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Domain.Wallet;
using Domain.Transaction;
using Domain.Ledger;

namespace Infrastructure.Persitence
{
    public class DwContext:DbContext
    {
        public DwContext():base()
        {

        }

        public DbSet<Wallet> Wallet;
        public DbSet<Transaction> Transaction;
        public DbSet<Ledger> Ledger;

    }
}
