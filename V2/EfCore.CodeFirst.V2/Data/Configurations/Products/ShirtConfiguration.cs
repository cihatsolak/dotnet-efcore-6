namespace EfCore.CodeFirst.V2.Data.Configurations.Products
{
    public class ShirtConfiguration : IEntityTypeConfiguration<Shirt>
    {
        public void Configure(EntityTypeBuilder<Shirt> builder)
        {
            builder.ToTable(nameof(Shirt),
                p =>
                {
                    p.HasCheckConstraint("StockCannotBeLessThanZero", "[Stock]>=0");
                    p.HasCheckConstraint("PriceMustBeGreaterThanZero", "[Price]>=0");
                    p.HasCheckConstraint("KdvCannotBeLessThanZero", "[Kdv]>=0");
                });

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever(); //[DatabaseGenerated(DatabaseGeneratedOption.None)]

            builder.Property(p => p.Name).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Price).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Kdv).IsRequired();

            builder.Property(p => p.SalesPrice)
                .HasPrecision(18,2)
                .ValueGeneratedOnAddOrUpdate()
                .HasComputedColumnSql("[Price]*[Kdv]"); //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]

            builder.Property(p => p.CreatedDate)
                .ValueGeneratedOnAdd() //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                .IsRequired();
        }
    }
}
