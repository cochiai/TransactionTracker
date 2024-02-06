using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TransactionTracker.Interfaces;
using TransactionTracker.Models;
using TransactionTracker.ViewModels;

namespace TransactionTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionTrackerService _service;

        public HomeController(ILogger<HomeController> logger, ITransactionTrackerService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // 1: Default user
            var transactions = await _service.GetTransactionsAsync(1);
            _logger.LogInformation("GetTransactionsAsync() successfully called.");
            // Ajax
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_TransactionTable", transactions);
            }
            return View(transactions);
        }
        public async Task<IActionResult> AddTransaction(int id)
        {
            AddTransactionViewModel addTransactionViewModel = new AddTransactionViewModel();
            addTransactionViewModel.Categories = (await _service.GetCategoriesAsync()).OrderBy(c => c.Name).ToList();
            _logger.LogInformation("GetCategoriesAsync() successfully called.");
            addTransactionViewModel.Recipients = (await _service.GetRecipientsAsync()).OrderBy(c => c.Name).ToList();
            _logger.LogInformation("GetRecipientsAsync() successfully called.");
            addTransactionViewModel.Currencies = (await _service.GetCurrenciesAsync()).OrderBy(c => c.Abbreviation).ToList();            
            _logger.LogInformation("GetCurrenciesAsync() successfully called.");

            addTransactionViewModel.Transaction.Date = DateTime.Now;

            if (id > 0)
            {
                addTransactionViewModel.Transaction = await _service.GetTransactionAsync(id);
            }

            return PartialView("_AddTransactionModalForm", addTransactionViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddTransaction(AddTransactionViewModel addTransactionViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add
                if (addTransactionViewModel.Transaction.Id == 0)
                {
                    // Default user
                    addTransactionViewModel.Transaction.SenderId = 1;
                    await _service.PostTransactionAsync(addTransactionViewModel.Transaction);
                    _logger.LogInformation("PostTransactionAsync() successfully called.");
                }
                // Edit
                else
                {
                    await _service.PutTransactionAsync(addTransactionViewModel.Transaction);
                    _logger.LogInformation("PutTransactionAsync() successfully called.");
                }
            }
            else
            {
                _logger.LogError("AddTransaction(): ModelState is invalid.");
            }
            return PartialView("_AddTransactionModalForm", addTransactionViewModel);
        }

        [HttpPost]
        public async void DeleteTransaction(int id)
        {
            await _service.DeleteTransactionAsync(id);
            _logger.LogInformation("GetCategoriesAsync() successfully called.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
