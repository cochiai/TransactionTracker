using System.ComponentModel.DataAnnotations;

namespace TransactionTrackerService.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(450)]
        public string Abbreviation { get; set; } = string.Empty;
        public ICollection<Person> Persons { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = null!;
    }
}
