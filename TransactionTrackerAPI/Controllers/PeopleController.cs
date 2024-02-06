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
    public class PeopleController : ControllerBase
    {
        private readonly TransactionTrackerDBContext _context;

        private readonly ILogger<PeopleController> _logger;
        public PeopleController(TransactionTrackerDBContext context, ILogger<PeopleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            _logger.LogInformation("GetPersons() called.");
            return await _context.Persons.ToListAsync();
        }
    }
}
