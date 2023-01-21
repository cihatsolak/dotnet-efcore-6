namespace EfCore.CodeFirst.V2.Data.Entities
{
    [Table("Bank")]
    public class Bank : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Column(Order = 2)]
        public string Name { get; set; }

        [Column(TypeName = "nchar", Order = 3)]
        [StringLength(5)]
        [Required]
        public string BranchCode { get; set; }

        [Column("BankAddress", Order = 4)]
        [MaxLength(200)]
        [Required]
        public string Address { get; set; }
    }
}
