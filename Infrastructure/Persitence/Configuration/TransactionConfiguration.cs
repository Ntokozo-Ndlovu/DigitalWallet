using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Transaction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DWContext.EntityConfiguration
{
    public class TransactionConfiguration:IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {

        }

    }
}
