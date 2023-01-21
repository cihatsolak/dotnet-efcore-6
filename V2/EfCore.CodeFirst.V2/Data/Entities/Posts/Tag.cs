namespace EfCore.CodeFirst.V2.Data.Entities.Posts
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
