namespace EfCore.CodeFirst.V2.Data.Configurations.Galleries
{
    public class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.ToTable(nameof(Gallery));
            builder.HasNoKey();
        }
    }
}
