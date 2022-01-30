using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM.Data;
using WFM.Models;

namespace WFM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMetersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerMetersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerMeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMeters>>> GetCustomerMeters()
        {
            return await _context.CustomerMeters.ToListAsync();
        }

        // GET: api/CustomerMeters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMeters>> GetCustomerMeters(int id)
        {
            var customerMeters = await _context.CustomerMeters.FindAsync(id);

            if (customerMeters == null)
            {
                return NotFound();
            }

            return customerMeters;
        }

        // PUT: api/CustomerMeters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerMeters(int id, CustomerMeters customerMeters)
        {
            if (id != customerMeters.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerMeters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMetersExists(id))
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

        // POST: api/CustomerMeters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerMeters>> PostCustomerMeters(CustomerMeters customerMeters)
        {
            _context.CustomerMeters.Add(customerMeters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerMeters", new { id = customerMeters.Id }, customerMeters);
        }

        // DELETE: api/CustomerMeters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerMeters>> DeleteCustomerMeters(int id)
        {
            var customerMeters = await _context.CustomerMeters.FindAsync(id);
            if (customerMeters == null)
            {
                return NotFound();
            }

            _context.CustomerMeters.Remove(customerMeters);
            await _context.SaveChangesAsync();

            return customerMeters;
        }

        private bool CustomerMetersExists(int id)
        {
            return _context.CustomerMeters.Any(e => e.Id == id);
        }
    }
}
