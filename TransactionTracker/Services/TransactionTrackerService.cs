using System.Text;
using System.Text.Json;
using TransactionTracker.Helpers;
using TransactionTracker.Interfaces;
using TransactionTracker.Models;

namespace TransactionTracker.Services
{
    public class TransactionTrackerService : ITransactionTrackerService
    {
        private readonly HttpClient _client;

        public TransactionTrackerService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var response = await _client.GetAsync("/api/categories");

            return await response.ReadContentAsync<List<Category>>();
        }
        public async Task<IEnumerable<Person>> GetRecipientsAsync()
        {
            var response = await _client.GetAsync("/api/people");

            return await response.ReadContentAsync<List<Person>>();
        }
        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            var response = await _client.GetAsync("/api/currencies");

            return await response.ReadContentAsync<List<Currency>>();
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int senderId)
        {
            var response = await _client.GetAsync("/api/transactions/"+senderId);

            return await response.ReadContentAsync<List<Transaction>>();
        }
        public async Task<Transaction> GetTransactionAsync(int id)
        {
            var response = await _client.GetAsync("/api/transactions/transaction/" + id);

            return await response.ReadContentAsync<Transaction>();
        }
        public async Task PostTransactionAsync(Transaction transaction)
        {
            //var json = JsonSerializer.Serialize(transaction);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsJsonAsync("/api/transactions", transaction);
        }
        public async Task PutTransactionAsync(Transaction transaction)
        {
            var response = await _client.PutAsJsonAsync("/api/transactions/" + transaction.Id, transaction);
        }
        public async Task DeleteTransactionAsync(int id)
        {
            var response = await _client.DeleteAsync("/api/transactions/" + id);
        }
    }
}
