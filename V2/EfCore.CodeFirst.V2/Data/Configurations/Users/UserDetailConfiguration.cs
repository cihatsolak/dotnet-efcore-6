namespace EfCore.CodeFirst.V2.Data.Configurations.Users
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable(nameof(UserDetail));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn(1, 1);

            builder.Property(p => p.PhoneNumber).HasMaxLength(10).IsFixedLength().IsRequired();

            builder.HasOne(p => p.User).WithOne(p => p.UserDetail).HasForeignKey<UserDetail>(p => p.UserId);
        }
    }
}
