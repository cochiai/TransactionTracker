using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionTrackerService.Filters;
using TransactionTrackerService.Models;
using TransactionTrackerService.ViewModels;

namespace TransactionTrackerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionTrackerDBContext _context;

        private readonly ILogger<TransactionsController> _logger;
        public TransactionsController(TransactionTrackerDBContext context, ILogger<TransactionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Transactions
        [HttpGet("{senderId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int senderId)
        {
            _logger.LogInformation("GetTransactions(senderId) called.");

            return await _context.Transactions.AsNoTracking().Include(t => t.Category).Include(t => t.Recipient).Include(t => t.Currency).Where(t => t.SenderId == senderId).ToListAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("transaction/{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            _logger.LogInformation("GetTransaction(id) called.");
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, TransactionViewModel transactionViewModel)
        {
            _logger.LogInformation("PutTransaction() called.");
            Transaction transaction = new Transaction(transactionViewModel);
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("PutTransaction() sucessfully called.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionViewModel transactionViewModel)
        {
            _logger.LogInformation("PostTransaction() called.");
            // Validation
            if (_context.Persons.Any(e => e.Id == transactionViewModel.RecipientId)
                && _context.Persons.Any(e => e.Id == transactionViewModel.SenderId)
                && _context.Currencies.Any(e => e.Id == transactionViewModel.CurrencyId)
                && _context.Categories.Any(e => e.Id == transactionViewModel.CategoryId))
            {
                Transaction transaction = new Transaction(transactionViewModel);
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                _logger.LogInformation("PostTransaction() new transaction successfully added.");
                return Ok();
                //return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
            }
            else
            { 
                _logger.LogError("Recipient, Sender, Currency and/or Category do not exist.");
                return BadRequest();
            }
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
