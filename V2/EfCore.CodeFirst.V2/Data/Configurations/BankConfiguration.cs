namespace EfCore.CodeFirst.V2.Data.Configurations
{
    public sealed class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable(nameof(Bank));

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).UseIdentityColumn(1, 1);

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BranchCode).HasMaxLength(5).IsFixedLength(true).IsRequired();

            builder.Property(p => p.Address).HasColumnName("BankAddress").HasMaxLength(200).IsRequired();

            builder.Property(p => p.CreatedDate).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(p => p.UpdatedDate).HasDefaultValueSql("getdate()").IsRequired();
        }
    }
}
