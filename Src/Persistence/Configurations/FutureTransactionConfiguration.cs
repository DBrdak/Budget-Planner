using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class FutureTransactionConfiguration : IEntityTypeConfiguration<FutureTransaction>

    {
        public void Configure(EntityTypeBuilder<FutureTransaction> builder)
        {
            builder.Property(ft => ft.Date).HasColumnType("Date");

            builder.HasMany(ft => ft.CompletedTransactions)
                .WithOne(t => t.FutureTransaction)
                .HasForeignKey(t => t.FutureTransactionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}