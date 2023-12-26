using Company.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Account).WithMany(x=>x.Transactions).HasForeignKey(x=>x.Id);
            builder.Property(x => x.Value).IsRequired();
            builder.ToTable("Transactions");
        }
    }
}
