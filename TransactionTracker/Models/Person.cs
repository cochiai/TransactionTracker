using System.ComponentModel.DataAnnotations;

namespace TransactionTracker.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Company { get; set; }
        public string Name { get { return  string.IsNullOrEmpty(Company) ? Firstname + " " + Lastname : Company; } }
        //[Required]
        //public Currency Currency { get; set; } = new();
        public List<Transaction> SenderTransactions { get; set; } = new();
        public List<Transaction> RecipientTransactions { get; set; } = new();
    }
}
