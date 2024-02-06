using System.ComponentModel.DataAnnotations;
using TransactionTrackerService.Models;

namespace TransactionTrackerService.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public string? Note { get; set; }
    }
}
