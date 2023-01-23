namespace EfCore.CodeFirst.V2.Data.Entities.Galleries
{
    [Keyless]
    public class Gallery
    {
        public string Text { get; set; }
        public int Year { get; set; }

        [Column(TypeName = "varchar")]
        public string Url { get; set; }
    }
}
