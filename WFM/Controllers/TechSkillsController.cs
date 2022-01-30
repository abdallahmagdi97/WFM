using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM.Data;
using WFM.Models;

namespace WFM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TechSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechSkills>>> GetTechSkills()
        {
            return await _context.TechSkills.ToListAsync();
        }

        // GET: api/TechSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechSkills>> GetTechSkills(int id)
        {
            var techSkills = await _context.TechSkills.FindAsync(id);

            if (techSkills == null)
            {
                return NotFound();
            }

            return techSkills;
        }

        // GET: api/TechSkills/5

        [Route("GetTechWithSkills/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TechSkills>>> GetTechWithSkills(int id)
        {
            var techSkills = await _context.TechSkills.Where(x => x.SkillRefId == id).ToListAsync();

            if (techSkills == null)
            {
                return NotFound();
            }

            return techSkills;
        }

        // PUT: api/TechSkills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechSkills(int id, TechSkills techSkills)
        {
            if (id != techSkills.Id)
            {
                return BadRequest();
            }

            _context.Entry(techSkills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechSkillsExists(id))
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

        // POST: api/TechSkills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TechSkills>> PostTechSkills(TechSkills techSkills)
        {
            var ts = await _context.TechSkills.Where(x => x.SkillRefId == techSkills.SkillRefId && x.TechRefId == techSkills.TechRefId).ToListAsync();
            if (ts.Count() != 0)
            {
                return BadRequest("Record Already Exists");
            }
            _context.TechSkills.Add(techSkills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechSkills", new { id = techSkills.Id }, techSkills);
        }

        // DELETE: api/TechSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TechSkills>> DeleteTechSkills(int id)
        {
            var techSkills = await _context.TechSkills.FindAsync(id);
            if (techSkills == null)
            {
                return NotFound();
            }

            _context.TechSkills.Remove(techSkills);
            await _context.SaveChangesAsync();

            return techSkills;
        }

        private bool TechSkillsExists(int id)
        {
            return _context.TechSkills.Any(e => e.Id == id);
        }
    }
}
