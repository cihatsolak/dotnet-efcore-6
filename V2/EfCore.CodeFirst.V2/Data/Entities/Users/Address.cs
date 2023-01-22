namespace EfCore.CodeFirst.V2.Data.Entities.Users
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string PlaceOfResidence { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
