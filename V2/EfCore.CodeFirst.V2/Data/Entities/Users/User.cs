namespace EfCore.CodeFirst.V2.Data.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public UserDetail UserDetail { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
