namespace EfCore.CodeFirst.V2.Data.Entities
{
    public class Shoe
    {
        public string Color { get; set; }
        public int Size { get; set; }

        //Row version tipinin kesinlikle byte[] olması gerekmektedir.
        public byte[] RowVersion { get; set; }
    }
}
