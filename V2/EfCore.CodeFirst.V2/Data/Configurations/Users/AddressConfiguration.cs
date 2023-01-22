namespace EfCore.CodeFirst.V2.Data.Configurations.Users
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
            builder.HasOne(p => p.User).WithMany(p => p.Addresses).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
