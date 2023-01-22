namespace EfCore.CodeFirst.V2.Data.Entities.Vehicles
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Chassis { get; set; }

        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
