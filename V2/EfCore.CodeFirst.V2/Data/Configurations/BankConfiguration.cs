﻿namespace EfCore.CodeFirst.V2.Data.Configurations
{
    public sealed class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable(nameof(Bank));

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).UseIdentityColumn(1, 1);
        }
    }
}
