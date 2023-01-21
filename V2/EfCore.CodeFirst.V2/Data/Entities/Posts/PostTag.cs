namespace EfCore.CodeFirst.V2.Data.Entities.Posts
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
