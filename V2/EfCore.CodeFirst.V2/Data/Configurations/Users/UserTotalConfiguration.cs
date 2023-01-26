namespace EfCore.CodeFirst.V2.Data.Configurations.Users
{
    public class UserTotalConfiguration : IEntityTypeConfiguration<UserTotal>
    {
        public void Configure(EntityTypeBuilder<UserTotal> builder)
        {
            builder.HasNoKey();
            builder.ToTable(p => p.ExcludeFromMigrations());
        }
    }
}
