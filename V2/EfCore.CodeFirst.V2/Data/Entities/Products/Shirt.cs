namespace EfCore.CodeFirst.V2.Data.Entities.Products
{
    public class Shirt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //Fluent API: ValueGeneratedNever() 
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //Fluent API: ValueGeneratedOnAddOrUpdate() 
        public decimal SalesPrice { get; set; }
        public int Kdv { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Fluent API: ValueGeneratedOnAdd() 
        public DateTime CreatedDate { get; set; }
    }
}
