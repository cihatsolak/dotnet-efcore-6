namespace EfCore.CodeFirst.V2.Data.Entities
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
