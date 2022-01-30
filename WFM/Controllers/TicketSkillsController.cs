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
    public class TicketSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketSkills>>> GetTicketSkills()
        {
            return await _context.TicketSkills.ToListAsync();
        }

        // GET: api/TicketSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketSkills>> GetTicketSkills(int id)
        {
            var ticketSkills = await _context.TicketSkills.FindAsync(id);

            if (ticketSkills == null)
            {
                return NotFound();
            }

            return ticketSkills;
        }

        // PUT: api/TicketSkills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketSkills(int id, TicketSkills ticketSkills)
        {
            if (id != ticketSkills.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketSkills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketSkillsExists(id))
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

        // POST: api/TicketSkills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TicketSkills>> PostTicketSkills(TicketSkills ticketSkills)
        {
            _context.TicketSkills.Add(ticketSkills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketSkills", new { id = ticketSkills.Id }, ticketSkills);
        }

        // DELETE: api/TicketSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketSkills>> DeleteTicketSkills(int id)
        {
            var ticketSkills = await _context.TicketSkills.FindAsync(id);
            if (ticketSkills == null)
            {
                return NotFound();
            }

            _context.TicketSkills.Remove(ticketSkills);
            await _context.SaveChangesAsync();

            return ticketSkills;
        }

        private bool TicketSkillsExists(int id)
        {
            return _context.TicketSkills.Any(e => e.Id == id);
        }
    }
}
