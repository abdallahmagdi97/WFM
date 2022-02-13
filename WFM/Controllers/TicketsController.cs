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
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            var tickets = await _context.Ticket.ToListAsync();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == ticket.Id).ToListAsync();
                var skills = new List<int>();
                foreach (var skill in ticketSkills)
                {
                    skills.Add(skill.SkillRefId);
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return ticketList;
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            foreach (var skill in ticketSkills)
                skills.Add(skill.SkillRefId);
            ticket.Skills = skills;
            return ticket;
        }
        // GET: api/Customers/GetStatusTickets/5
        [Route("GetStatusTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetStatusTickets(int id)
        {
            var tickets = await _context.Ticket.Where(x => x.StatusRefId == id).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    skills.Add(skill.SkillRefId);
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return ticketList;
        }
        // GET: api/Customers/GetTechTickets/5
        [Route("GetTechTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTechTickets(int id)
        {
            var tickets = await _context.Ticket.Where(x => x.TechRefId == id).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    skills.Add(skill.SkillRefId);
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return ticketList;
        }
        // GET: api/Customers/GetCustomerMeters/5
        [Route("GetCustomerTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetCustomerTickets(int id)
        {
            var tickets = await _context.Ticket.Where(x => x.CustomerRefId == id).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    skills.Add(skill.SkillRefId);
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return ticketList;
        }
        // GET: api/Customers/GetMeterTickets/5
        [Route("GetMeterTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetMeterTickets(int id)
        {
            var tickets = await _context.Ticket.Where(x => x.MeterRefId == id).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    skills.Add(skill.SkillRefId);
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return ticketList;
        }
        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;
            foreach (var skill in ticket.Skills)
            {
                var ticketSkill = new TicketSkills() { TicketRefId = id, SkillRefId = skill };
                var ticketSkillExists = _context.TicketSkills.Any(a => a.SkillRefId == ticketSkill.SkillRefId && a.TicketRefId == ticketSkill.TicketRefId);
                if (!ticketSkillExists)
                    _context.TicketSkills.Add(ticketSkill);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Ticket updated successfully" });
        }

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            ticket.CreationDate = DateTime.Now;
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();
            foreach (var skill in ticket.Skills)
            {
                var ticketSkill = new TicketSkills() { TicketRefId = ticket.Id, SkillRefId = skill };
                ticket.Skills.Add(skill);
                _context.TicketSkills.Add(ticketSkill);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            var ticketSkills = await _context.TicketSkills.Where(ts => ts.TicketRefId == id).ToListAsync();
            if (ticketSkills.Count == 0)
                return ticket;
            foreach (var ticketSkill in ticketSkills)
                _context.TicketSkills.Remove(ticketSkill);
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Ticket deleted successfully" });
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
