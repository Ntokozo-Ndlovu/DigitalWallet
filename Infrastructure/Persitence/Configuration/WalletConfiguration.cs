using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Wallet;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DWContext.EntityConfiguration
{
    public class WalletConfiguration:IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> entity)
        {

        }
    }
}
