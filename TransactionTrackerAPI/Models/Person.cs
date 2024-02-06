using System.ComponentModel.DataAnnotations;

namespace TransactionTrackerService.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Company { get; set; }
        //[Required]
        //public Currency Currency { get; set; } = new();
        public ICollection<Transaction> SenderTransactions { get; set; } = null!;
        public ICollection<Transaction> RecipientTransactions { get; set; } = null!;
    }
}
