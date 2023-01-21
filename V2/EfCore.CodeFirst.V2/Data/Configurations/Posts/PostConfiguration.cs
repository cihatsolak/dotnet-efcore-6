namespace EfCore.CodeFirst.V2.Data.Configurations.Posts
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>("PostTag",
                    x => x.HasOne<Tag>().WithMany().HasForeignKey("TagId").HasConstraintName("FK_PostTag_Tags_TagId"),
                    x => x.HasOne<Post>().WithMany().HasForeignKey("PostId").HasConstraintName("FK_PostTag_Posts_PostId")
            );
        }
    }
}
