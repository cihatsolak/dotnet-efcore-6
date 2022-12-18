namespace EfCore.CodeFirst.DAL
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Section { get; set; }

        public Product Product { get; set; }
    }
}
