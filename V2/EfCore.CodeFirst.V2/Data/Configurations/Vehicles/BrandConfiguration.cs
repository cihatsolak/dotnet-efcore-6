namespace EfCore.CodeFirst.V2.Data.Configurations.Vehicles
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable(nameof(Brand));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn(1, 1);

            //builder.HasMany(p => p.Vehicles).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(p => p.Vehicles).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Vehicles).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
