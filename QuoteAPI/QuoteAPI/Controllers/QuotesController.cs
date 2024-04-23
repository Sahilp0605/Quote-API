using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using QuoteAPI.ApplicationDbContext;
using QuoteAPI.Model;


namespace QuoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteDbContext _context;

        public QuotesController(QuoteDbContext context)
        {
            _context = context;
        }


        // GET: api/Quote/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Quote>>> SearchQuotes(string searchKey)
        {
            if (string.IsNullOrEmpty(searchKey))
            {
                return BadRequest("Search key cannot be empty.");
            }

            IQueryable<Quote> query = _context.Quote.Where(q =>
                q.Author.Contains(searchKey) ||
                q.QuoteName.Contains(searchKey) 
            );

            var result = await query.ToListAsync();

            return Ok(result);
        }




        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuote()
        {
            if (_context.Quote == null)
            {
                return NotFound();
            }
            return await _context.Quote.ToListAsync();
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            if (_context.Quote == null)
            {
                return NotFound();
            }
            var quote = await _context.Quote.FindAsync(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, Quote quote)
        {
            if (id != quote.Id)
            {
                return BadRequest();
            }

            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        // POST: api/Quotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        {
            if (_context.Quote == null)
            {
                return Problem("Entity set 'QuoteDbContext.Quote'  is null.");
            }
            _context.Quote.Add(quote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuote", new { id = quote.Id }, quote);
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            if (_context.Quote == null)
            {
                return NotFound();
            }
            var quote = await _context.Quote.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.Quote.Remove(quote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuoteExists(int id)
        {
            return (_context.Quote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
