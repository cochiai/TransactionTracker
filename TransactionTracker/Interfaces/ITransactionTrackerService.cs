using TransactionTracker.Models;

namespace TransactionTracker.Interfaces
{
    public interface ITransactionTrackerService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Person>> GetRecipientsAsync();
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task<IEnumerable<Transaction>> GetTransactionsAsync(int senderId);
        Task<Transaction> GetTransactionAsync(int id);
        Task PostTransactionAsync(Transaction transaction);
        Task PutTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
    }
}
