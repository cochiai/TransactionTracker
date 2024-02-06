using System.ComponentModel.DataAnnotations;

namespace TransactionTracker.Models
{
    public class Currency
    {
        public int Id { get; set; }
        [StringLength(450)]
        public string Name { get; set; } = string.Empty;
        [StringLength(450)]
        public string Abbreviation { get; set; } = string.Empty;
        public List<Person> Persons { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
    }
}
