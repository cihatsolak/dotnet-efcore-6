namespace EfCore.CodeFirst.DAL
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
