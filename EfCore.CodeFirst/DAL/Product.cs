using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.CodeFirst.DAL
{
    public class Product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal SalesPrice { get; set; }
        public decimal Kdv { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedDate { get; set; }

        public int Barcode { get; set; }

        public ProductFeature ProductFeature { get; set; }
    }
}
