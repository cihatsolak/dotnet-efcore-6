namespace EfCore.CodeFirst.V2.Data.Configurations.Functions
{
    public class UserGalleryFullConfiguration : IEntityTypeConfiguration<UserGalleryFull>
    {
        public void Configure(EntityTypeBuilder<UserGalleryFull> builder)
        {
            builder.HasNoKey().ToTable(p => p.ExcludeFromMigrations());
            builder.ToFunction("fc_user_gallery_full");

            //CREATE FUNCTION fc_user_gallery_full()
            //RETURNS TABLE
            //AS
            //RETURN
            //(
            //    SELECT[User].[Name], [User].Age, [Gallery].[Year]

            //    FROM[User]

            //    INNER JOIN[Gallery] on Gallery.UserId = [User].Id
            //)
            //GO


            //CREATE FUNCTION fc_user_gallery_by_age(@age int)
            //RETURNS TABLE 
            //AS
            //RETURN 
            //(
	           // SELECT [User].[Name], [User].Age, [Gallery].[Year]
	           // FROM [User] 
	           // INNER JOIN [Gallery] on Gallery.UserId = [User].Id
	           // WHERE [USER].Age > @age
            //)
            //GO
        }
    }
}


