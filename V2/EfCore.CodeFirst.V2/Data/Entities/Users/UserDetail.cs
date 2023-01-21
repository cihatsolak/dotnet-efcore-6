namespace EfCore.CodeFirst.V2.Data.Entities.Users
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
