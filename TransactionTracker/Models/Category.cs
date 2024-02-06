using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace TransactionTracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(450)]
        public string Name { get; set; } = string.Empty;
        public List<Transaction> Transactions { get; set; } = new();
    }
}
