namespace EfCore.CodeFirst.V2.Data.Entities.Posts
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
