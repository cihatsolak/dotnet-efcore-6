namespace EfCore.CodeFirst.DAL
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Year { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
