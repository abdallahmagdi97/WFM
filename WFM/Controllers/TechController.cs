using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM.Data;
using WFM.Models;
using Microsoft.AspNetCore.Authorization;

namespace WFM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tech
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tech>>> GetTech()
        {
            return await _context.Tech.ToListAsync();
        }

        // GET: api/Tech/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tech>> GetTech(int id)
        {
            var tech = await _context.Tech.FindAsync(id);

            if (tech == null)
            {
                return NotFound();
            }

            return tech;
        }

        // PUT: api/Tech/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTech(int id, Tech tech)
        {
            if (id != tech.Id)
            {
                return BadRequest();
            }

            _context.Entry(tech).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechExists(id))
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

        // POST: api/Tech
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tech>> PostTech(Tech tech)
        {
            _context.Tech.Add(tech);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTech", new { id = tech.Id }, tech);
        }

        // DELETE: api/Tech/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tech>> DeleteTech(int id)
        {
            var tech = await _context.Tech.FindAsync(id);
            if (tech == null)
            {
                return NotFound();
            }

            _context.Tech.Remove(tech);
            await _context.SaveChangesAsync();

            return tech;
        }

        private bool TechExists(int id)
        {
            return _context.Tech.Any(e => e.Id == id);
        }
    }
}
