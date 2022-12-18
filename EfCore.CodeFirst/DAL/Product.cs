namespace EfCore.CodeFirst.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Barcode { get; set; }

        public ProductFeature ProductFeature { get; set; }
    }
}
