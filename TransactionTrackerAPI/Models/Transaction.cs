using System.ComponentModel.DataAnnotations;
using TransactionTrackerService.ViewModels;

namespace TransactionTrackerService.Models
{
    public class Transaction
    {
        public Transaction() { }
        public Transaction(TransactionViewModel transactionViewModel) 
        {
            if (transactionViewModel != null)
            { 
                Id = transactionViewModel.Id;
                Name = transactionViewModel.Name;
                Description = transactionViewModel.Description;
                Date = transactionViewModel.Date;
                CategoryId = transactionViewModel.CategoryId;
                SenderId = transactionViewModel.SenderId;
                RecipientId = transactionViewModel.RecipientId;
                Amount = transactionViewModel.Amount;
                CurrencyId = transactionViewModel.CurrencyId;
                Note = transactionViewModel.Note;
                CreationDate = DateTime.Now;
            }
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        [Required]
        public int SenderId { get; set; }
        public Person Sender { get; set; } = null!;
        [Required]
        public int RecipientId { get; set; }
        public Person Recipient { get; set; } = null!;
        [Required]
        public double Amount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
        public string? Note { get; set; }
        public DateTime CreationDate { get; set; }
        //public double AmountSenderCurrency { get; set; }
        //public double AmountRecipientCurrency { get; set; }

    }
}
