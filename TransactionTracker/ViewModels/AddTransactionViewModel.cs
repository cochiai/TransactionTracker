using TransactionTracker.Models;

namespace TransactionTracker.ViewModels
{
    public class AddTransactionViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Person> Recipients { get; set; } = new List<Person>();
        public IEnumerable<Currency> Currencies { get; set; } = new List<Currency>();
        public Transaction Transaction { get; set; } = new();
    }
}
