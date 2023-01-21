namespace EfCore.CodeFirst.V2.Data.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User), p => p.HasCheckConstraint("UserCannotBeYoungerThanEighteen", "[Age]>18"));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn(1, 1);

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.Property(p => p.Age).HasDefaultValue(18).IsRequired();
        }
    }
}
