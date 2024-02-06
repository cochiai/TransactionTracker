using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionTrackerService.Models;

namespace TransactionTrackerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly TransactionTrackerDBContext _context;

        private readonly ILogger<CurrenciesController> _logger;
        public CurrenciesController(TransactionTrackerDBContext context, ILogger<CurrenciesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            _logger.LogInformation("GetCurrencies() called.");
            return await _context.Currencies.ToListAsync();
        }
    }
}
