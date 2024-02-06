using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TransactionTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string DateShortString { get { return Date.ToShortDateString(); } }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();
        [Required]
        public int SenderId { get; set; }
        public Person Sender { get; set; } = new();
        [Required]
        public int RecipientId { get; set; }
        public Person Recipient { get; set; } = new();
        [Required]
        [DisplayName("Amount")]
        public double Amount { get; set; }
        public string AmountString { get { return Amount.ToString("N"); } }
        [Required]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = new();
        public string? Note { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
